﻿﻿using System.ComponentModel.DataAnnotations;

namespace DeviceApp.api.Model
{
    /*
     * Model used transferring the data from request
     * In this api use case, all model fields are same as the repo object
     */
    public class DeviceModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Colour { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        [Range(1950,3000)]
        public int Year { get; set; }
        
        [Required]
        [StringLength(100)]
        public string CountryManufactured { get; set; }
    }
}