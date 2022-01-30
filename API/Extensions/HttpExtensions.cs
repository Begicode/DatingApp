using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Helpers;
using Microsoft.AspNetCore.Http;

namespace API.Extensions
{
    public static class HttpExtension
    {
        public static void AddPaginationHeader(this HttpResponse response, int curentPage,
             int itemsPerPage,int totalItems,int totalPages)
        {
            var paginationHeader = new PaginationHeader(curentPage,itemsPerPage,totalItems,totalPages);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy=JsonNamingPolicy.CamelCase
            };

            response.Headers.Add("Pagination",JsonSerializer.Serialize(paginationHeader,options));
            response.Headers.Add("Access-Control-Expose-Headers","Pagination");
        }
    }
}