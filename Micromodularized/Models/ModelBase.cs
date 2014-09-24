using System;
using System.Net;
using System.Threading.Tasks;
namespace Micromodularized.Models
{   
    public abstract class ModelBase
    {
        public string ext1 { get; set; }
        public string ext2 { get; set; }

        protected ModelBase()
        {
        }
    }
}