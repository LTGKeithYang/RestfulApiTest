using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    /// <summary>
    /// Animal
    /// </summary>
    public class Animal
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// animal name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// is or is not extinct
        /// </summary>
        public bool IsExtinct { get; set; }
    }
}