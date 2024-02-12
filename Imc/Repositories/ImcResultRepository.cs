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
            if (imcParameters.Is65Plus)
            {
                if (result.ImcValue <= 22)
                    result.Status = IMCstatus.Magreza;
                else if (result.ImcValue < 27)
                    result.Status = IMCstatus.Normal;
                else
                    result.Status = IMCstatus.Sobrepeso;
            }
            else
            {
                if (result.ImcValue < 18.5)
                    result.Status = IMCstatus.Magreza;
                else if (result.ImcValue < 25)
                    result.Status = IMCstatus.Normal;
                else
                    result.Status = IMCstatus.Sobrepeso;
            }
            _localStorage.SetItem(key, result);
        }
    }
}
