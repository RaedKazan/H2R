﻿using ApplicationDomianEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationService.ViewModels
{
    public class GetJuiceViewModel
    {

        public GetJuiceViewModel(JuiceItem Model)
        {
            this.Id = Model.Id;
            this.Category = Model.CategoryId;
            this.BrandText = Model.Brand.Description;
            this.CategoryText = Model.Category.Description;
            this.Brand = Model.BrandId;
            this.Name = Model.Name;
            this.Description = Model.Description;
            this.SellingPrice = Model.SellingPrice;
            this.BuyingPrice = Model.BuyingPrice;
            this.Image = Model.Image;
            this.IsAvilable = Model.ElectricCigaretMangment.FirstOrDefault().IsAvilable;
            this.CurrentlyCountAvilabil = Model.ElectricCigaretMangment.FirstOrDefault().TotalyAvilable;
        }
        public GetJuiceViewModel(JuiceItem Model, List<NicotinePercentageView> nicotinePercentage)
        {
            this.Id = Model.Id;
            this.Category = Model.CategoryId;
            this.BrandText = Model.Brand.Description;
            this.CategoryText = Model.Category.Description;
            this.Brand = Model.BrandId;
            this.Name = Model.Name;
            this.Description = Model.Description;
            this.SellingPrice = Model.SellingPrice;
            this.BuyingPrice = Model.BuyingPrice;
            this.Image = Model.Image;
            this.IsAvilable = Model.ElectricCigaretMangment.FirstOrDefault().IsAvilable;
            this.CurrentlyCountAvilabil = Model.ElectricCigaretMangment.FirstOrDefault().TotalyAvilable;
            if (nicotinePercentage.Any())
            {
                NicotinePercentageView = nicotinePercentage;

            }
        }
        public GetJuiceViewModel()
        {
        }
        public int Id { get; set; }
        public int Category { get; set; }
        public int Brand { get; set; }
        public string CategoryText { get; set; }
        public string BrandText { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CurrentlyCountAvilabil { get; set; }
        public Double? SellingPrice { get; set; }
        public Double? BuyingPrice { get; set; }
        public byte[] Image { get; set; }
        public bool? IsAvilable { get; set; }
        public List<NicotinePercentage> NicotinePercentage { get; set; }
        public List<NicotinePercentageView> NicotinePercentageView { get; set; }

    }
    public class NicotinePercentageView
    {
        public int JuiceManagmentID { get; set; }
        public int Quantity { get; set; }
        public string NicotinePercentage { get; set; }
        public bool IsActive { get; set; }
    }
}
