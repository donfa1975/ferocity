using Ferocity.Data;
using Ferocity.Models;
using Microsoft.EntityFrameworkCore;

namespace Ferocity.Services;

public class AlumnoService
{
    private readonly IDbContextFactory<FerocityDbContext> _contextFactory;

    public AlumnoService(IDbContextFactory<FerocityDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<Talumno>> GetAlumnos()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Talumnos.ToListAsync();
    }

    public async Task<bool> AddAlumnoAsync(Talumno alumno)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        context.Talumnos.Add(alumno);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAlumnoAsync(Talumno alumno)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        context.Talumnos.Update(alumno);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<Talumno?> GetAlumnoByIdAsync(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Talumnos.FirstOrDefaultAsync(a => a.Idalumno == id);
    }

    public async Task<bool> DesactivaAlumnoAsync(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var alumno = await context.Talumnos.FirstOrDefaultAsync(a => a.Idalumno == id);
        if (alumno is null)
            return false;

        alumno.Activo = 0;
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ActivaAlumnoAsync(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var alumno = await context.Talumnos.FirstOrDefaultAsync(a => a.Idalumno == id);
        if (alumno is null)
            return false;

        alumno.Activo = 1;
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RegistraPagoAsync(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var alumno = await context.Talumnos.FirstOrDefaultAsync(a => a.Idalumno == id);
        if (alumno is null || !alumno.Valorapagar.HasValue)
            return false;

        var fechaPago = DateTime.Now;
        DateTime proximoPago;
        if (alumno.Tipo == "Mensual")
            proximoPago = fechaPago.AddMonths(1);
        else if (alumno.Tipo == "Diario")
            proximoPago = fechaPago.AddDays(1);
        else
            return false;

        alumno.Fechaultimopago = fechaPago;
        alumno.Proximopago = proximoPago;
        context.Tpagos.Add(new Tpago
        {
            Idalumno = alumno.Idalumno,
            Fecha = fechaPago,
            Valor = alumno.Valorapagar.Value,
            Tipo = 1
        });
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RegistraBiometria(int id, Tbiometrium bio)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var alumnoExiste = await context.Talumnos.AnyAsync(a => a.Idalumno == id);
        if (!alumnoExiste)
            return false;

        bio.Idalumno = id;
        bio.Fecha = DateTime.Now;
        context.Tbiometria.Add(bio);
        await context.SaveChangesAsync();
        return true;
    }
}
