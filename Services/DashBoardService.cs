using Ferocity.Data;
using Ferocity.Models;
using Microsoft.EntityFrameworkCore;

namespace Ferocity.Services
{
    public class DashBoardService
    {
        private readonly IDbContextFactory<FerocityDbContext> _contextFactory;

        public DashBoardService(IDbContextFactory<FerocityDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<int> GetTotalAlumnosAsync()
        {
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Talumnos.CountAsync(x => x.Activo == 1);
        }

        public async Task<List<Talumno>> GetProximosPagos()
        {
            var (inicio, fin) = ObtenerSemanaActual();
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Talumnos
                .Where(x => x.Activo == 1 && x.Proximopago >= inicio && x.Proximopago < fin)
                .OrderBy(x => x.Proximopago)
                .ThenBy(x => x.Apellidos)
                .ThenBy(x => x.Nombres)
                .ToListAsync();
        }

        public async Task<List<Tpago>> GetPagosSemanales()
        {
            var (inicio, fin) = ObtenerSemanaActual();
            await using var context = await _contextFactory.CreateDbContextAsync();
            return await context.Tpagos
                .Where(x => x.Fecha >= inicio && x.Fecha < fin)
                .ToListAsync();
        }

        private static (DateTime Inicio, DateTime Fin) ObtenerSemanaActual()
        {
            var hoy = DateTime.Today;
            var inicio = hoy.AddDays(-(int)hoy.DayOfWeek);
            return (inicio, inicio.AddDays(7));
        }
    }
}
