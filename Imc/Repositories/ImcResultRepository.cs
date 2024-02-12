using Imc.Models;
using Microsoft.JSInterop;
using System.Data.Common;

namespace Imc.Repositories
{
    public class ImcResultRepository
    {
        private readonly ILocalStorageService _localStorage;

        public ImcResultRepository(ILocalStorageService localStorage) => _localStorage = localStorage;
        public List<ImcResult> Get()
        {
            var result = new List<ImcResult>();
            for (var i=0; i < _localStorage.Length; i++)
            {
                var key = (i + 1).ToString();
                var item = _localStorage.GetItem<ImcResult>(key);

                if (item is not null)
                    result.Add(item);
                Console.WriteLine(item?.ImcValue);
            }
            return result;
        }

        public void Create(ImcResult result, ImcParameters imcParameters) 
        {
            var key = (_localStorage.Length + 1).ToString();
            result.ImcValue = imcParameters.Weight / (imcParameters.Height * imcParameters.Height);
            _localStorage.SetItem(key, result);
        }
    }
}
