
namespace Micromodularized.Models
{   
    public abstract class ModelBase
    {
        public string Name { get; set; }

        protected ModelBase()
        {
            Name = "hola";
        }
    }
}