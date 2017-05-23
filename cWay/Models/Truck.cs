using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static cWay.Models.Enums;

namespace cWay.Models
{
    public class Truck
    {
        [Key]
        public int TruckID { get; set; }

        [Display(Name = "Color")]
        [Required(ErrorMessage = "Color is required.")]
        [DataType(DataType.Text)]
        public string TruckColor { get; set; }

        [Display(Name = "Hours")]
        [Range(0, 200000)]
        public string TruckEngineHours { get; set; }

        [Display(Name = "Suspension Type")]
        [EnumDataType(typeof(SuspensionType))]
        public SuspensionType TruckSuspensionType { get; set; }

        [Display(Name = "Mileage")]
        [Range(0, 10000000)]
        public int TruckMileage { get; set; }

        [Display(Name = "VIN")]
        public string TruckVin { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public int TruckPrice { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string TruckDescription { get; set; }

        [Display(Name = "Sold")]
        public bool TruckIsSold { get; set; }

        [Display(Name = "Second Tank?")]
        public bool TruckHas2Tanks { get; set; }

        [Display(Name = "Tank 1 Size")]
        [Range(0, 200)]
        public int TruckTank1Size { get; set; }

        [Display(Name = "Tank 2 Size")]
        [Range(0, 200)]
        public int TruckTank2Size { get; set; }

        [Display(Name = "Brake Condition")]
        [EnumDataType(typeof(BrakeCondition))]
        public BrakeCondition TruckBrakeCondition { get; set; }

        [Display(Name = "Tire Condition")]
        [EnumDataType(typeof(TireCondion))]
        public TireCondion TruckTireCondition { get; set; }

        [Display(Name = "Has Sleeper")]
        public bool TruckHasSleeper { get; set; }

        [Display(Name = "For Sale?")]
        public bool TruckIsListed { get; set; }

        [Display(Name = "Dealer Notes")]
        [DataType(DataType.MultilineText)]
        public string TruckDealerNotes { get; set; }

        private DateTime? createdDate;
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return createdDate ?? DateTime.UtcNow; }
            set { createdDate = value; }
        }

        [Display(Name = "Date of Dealer Purchase")]
        [DataType(DataType.Date)]
        public DateTime TruckDealerDateOfPurchase { get; set; }

        [Display(Name = "Final Sale Price")]
        [DataType(DataType.Currency)]
        public int? TruckDealerFinalSalePrice { get; set; }

        [Display(Name = "Improvement Costs")]
        [DataType(DataType.Currency)]
        public int TruckDealerImprovementCost { get; set; }

        [Display(Name = "Date Sold")]
        [DataType(DataType.Date)]
        public DateTime? TruckDealerDateOfSale { get; set; }

        [Display(Name = "Dealer Purchase Cost")]
        [DataType(DataType.Currency)]
        public int TruckDealerPurchaseCost { get; set; }

        //TODO
        //Add images
        //public virtual ICollection<TruckImage> Images { get; set; }

        [Display(Name = "Cab Style")]
        [DataType(DataType.Text)]
        //API ID 4 - CAB TYPE
        public string TruckCabStyle { get; set; }

        #region API Tens

        [Display(Name = "Engine Model")]
        [DataType(DataType.Text)]
        //API ID 18 - ENGINE MODEL
        public string TruckEngineModel { get; set; }

        #endregion

        #region API Twentys

        [Display(Name = "Make")]
        [Required(ErrorMessage = "Truck make is required.")]
        [DataType(DataType.Text)]
        //API ID 26 - MAKE
        public string TruckMake { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "Truck model is required.")]
        [DataType(DataType.Text)]
        //API ID 28 - MODEL
        public string TruckModel { get; set; }

        [Display(Name = "Year")]
        [Range(1900, 2100)]
        [Required(ErrorMessage = "Truck year is required.")]
        //API ID 29 - MODEL YEAR
        public int TruckYear { get; set; }

        #endregion

        #region API Thirtys

        [Display(Name = "Transmission Type")]
        [EnumDataType(typeof(TransmissionType))]
        //API ID 37 - TRANSMISSION STYLE
        public TransmissionType TruckTransmissionType { get; set; }

        [Display(Name = "Vehicle Type")]
        [DataType(DataType.Text)]
        //API ID 39 - Vehicle Type
        public string TruckVehicleType { get; set; }

        #endregion

        #region API Fortys

        [Display(Name = "Brake Type")]
        [DataType(DataType.Text)]
        //API ID 42 - BRAKE SYSTEM TYPE
        public string TruckBrakeType { get; set; }

        #endregion

        #region API Sixtys

        [Display(Name = "Number of Gears")]
        //API ID 63 - TRANSMISSION SPEEDS
        public string TruckTransmissionSpeeds { get; set; }

        #endregion

        #region API OneHundre-Tens

        [Display(Name = "Wheel Base (inches)")]
        [DataType(DataType.Text)]
        //API ID 111 - Wheel Base (inches)
        public decimal TruckWheelBaseInches { get; set; }

        [Display(Name = "Front Wheel Size")]
        [DataType(DataType.Text)]
        //API ID 119 - Wheel Size Front (inches)
        public int TruckWheelSizeFront { get; set; }

        #endregion

        #region API OneHundred-Twentys

        [Display(Name = "Rear Wheel Size")]
        [DataType(DataType.Text)]
        //API ID 120 - Wheel Size Rear )inches)
        public int TruckWheelSizeRear { get; set; }

        #endregion

        #region API OneHundred-Thirtys

        [Display(Name = "Turbo")]
        [EnumDataType(typeof(Turbo))]
        //API ID 135 - Turbo
        public Turbo TruckTurbo { get; set; }

        #endregion

        #region API OneHundred-Fortys

        [Display(Name = "Axle Config")]
        [EnumDataType(typeof(AxleCount))]
        //API ID 145 - AXLE CONFIGURATION
        public AxleCount TruckAxleConfiguration { get; set; }

        [Display(Name = "Engine Make")]
        [DataType(DataType.Text)]
        //API ID 146 - ENGINE MANUFACTURER
        public string TruckEngineMake { get; set; }

        #endregion

        public virtual ICollection<Image> Images { get; set; }

    }

}
