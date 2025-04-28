
namespace Monix.Models
{
    public class Aplicativo
    {
        public string Nome { get; set; }
        public string Title { get; set; }
        public string ClassName { get; set; }
        public string ProcessName { get; set; }
        public string ExecutablePath { get; set; }
        public DateTime? DataUltimaChecagem { get; set; }
        public int QtdOk { get; set; }
        public int QtdErro { get; set; }
        public string Status { get; set; }
        public Aplicativo()
        {
            Nome = "";
            Title = "";
            ClassName = "";
            ProcessName = "";
            ExecutablePath = "";
            DataUltimaChecagem = null;
            QtdOk = 0;
            QtdErro = 0;
            Status = "";
        }
    }
}

