using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetGrooming.Models.ViewModels
{
    public class UpdatePet
    {
        //information needed to make update pet work
        //information about pets
        //information about species

        public Pet pet { get; set; }
        public List<Species> species { get; set; }
    }
}