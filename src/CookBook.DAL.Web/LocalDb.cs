using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace CookBook.DAL.Web
{
    public class LocalDb
    {
        const string InitializeInvokeName = "LocalDb.Initialize";
        const string InsertInvokeName = "LocalDb.Insert";
        const string GetByIdInvokeName = "LocalDb.GetById";

        private readonly IJSRuntime jsRuntime;

        public LocalDb(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task Initialize()
        {
            await jsRuntime.InvokeVoidAsync(InitializeInvokeName);
        }

        public async Task InsertAsync<T>(T entity)
        {
            await jsRuntime.InvokeVoidAsync(InsertInvokeName, entity);
        }

        public async Task<T> GetById<T>(Guid id)
        {
            return await jsRuntime.InvokeAsync<T>(GetByIdInvokeName, id);
        }
    }
}