using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDex.Helpers
{
    public static class HttpContextExtensions
    {
        public async static Task InsertarParametrosPaginacion<T>(this HttpContext httpContext,
            IQueryable<T> queryable, int cantidadRegistrosXPagina)
        {
            double cantidad = await queryable.CountAsync();
            double cantidadPaginas = Math.Ceiling(cantidad / cantidadRegistrosXPagina);
            httpContext.Response.Headers.Add("cantidadPaginas", cantidadPaginas.ToString());
        }
    }
}
