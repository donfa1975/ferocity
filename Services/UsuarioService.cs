using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Ferocity.Data;
using Ferocity.Models;
namespace Ferocity.Services
{
    public class UsuarioService
    {
        private readonly IDbContextFactory<FerocityDbContext> _contextFactory;

        private int nivelAcceso;
        private string nombreUsuario;

        public UsuarioService(IDbContextFactory<FerocityDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Tusuario>> GetUsuarios()
        {
            using var _context = await _contextFactory.CreateDbContextAsync();
            return await _context.Tusuarios.ToListAsync();
        }
        public async Task<bool> AddUsuarioAsync(Tusuario usuario)
        {
            using var _context = await _contextFactory.CreateDbContextAsync();
            
            _context.Tusuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateUsuarioAsync(Tusuario usuario)
        {
            using var _context = await _contextFactory.CreateDbContextAsync();
            _context.Tusuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> validaUsuario(string username, string password)
        {
            using var _context = await _contextFactory.CreateDbContextAsync();
            var usuario = await _context.Tusuarios.FirstOrDefaultAsync(u => u.Usuario == username);
            if (usuario != null && usuario.Password == password)
            {
                nivelAcceso = (int)usuario.Nivel;
                nombreUsuario = usuario.Usuario;
                return true;
            }
            return false;
        }
        /*public async Task<bool> ValidateUserCredentialsAsync(string email, string password)
        {
            var user = await GetUsuarioByEmailAsync(email);
            if (user == null)
                return false;
            // Assuming the password is stored as a hash, you would compare the hash of the provided password with the stored hash.
            // For simplicity, let's assume the password is stored in plain text (not recommended for production).
            return user.Password == password;
        }*/
    }
}
