using System.Collections.Generic;

namespace VacinneRegister.Core.DTOs
{
    public class ResponseDTo
    {
        public bool IsSucces { get; set; }

        public object Resuult { get; set; }

        public string DisplayMessage { get; set; }

        public List<string> ErrorMessages { get; set; }
    }
}
