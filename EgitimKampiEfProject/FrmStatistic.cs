using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EgitimKampiEfProject
{
	public partial class FrmStatistic : Form
	{
		public FrmStatistic()
		{
			InitializeComponent();
		}

		EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();

		private void FrmStatistic_Load(object sender, EventArgs e)
		{
			lblLocationCount.Text = db.Locations.Count().ToString();

			lblSumCapacity.Text = db.Locations.Sum(x => x.Capacity).ToString();

			lblGuideCount.Text = db.Guides.Count().ToString();

			lblAverageCapacity.Text =db.Locations.Average(x => x.Capacity).ToString();

			lblAverageLocationPrice.Text = db.Locations.Average(x => x.Price).ToString() + " ₺";

			int lastCountryId = db.Locations.Max(x => x.LocationId);
			lblLastCountryName.Text = db.Locations.Where(x => x.LocationId == lastCountryId).
				Select(y => y.Country).FirstOrDefault();

			lblCappadociaLocationCapacity.Text = db.Locations.Where(x => x.Name == "Kapadokya").
				Select(y => y.Capacity).FirstOrDefault().ToString();

			lblTurkiyeAverageCapacity.Text = db.Locations.Where(x => x.Country == "Türkiye").
				Average(y => y.Capacity).ToString();

			var romeGuideId = db.Locations.Where(x => x.Name == "Roma Turistik").Select(y => y.GuideId).FirstOrDefault();
			lblGuideOfRome.Text = db.Guides.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();
		
			var maxCapacity = db.Locations.Max(x=>x.Capacity);
			lblMaximumCapacityLocation.Text = db.Locations.Where(x=>x.Capacity == maxCapacity).Select(y=>y.Name).FirstOrDefault().ToString();

			var maxTourPrice = db.Locations.Max(x => x.Price);
			lblMaxPriceTour.Text = db.Locations.Where(x=> x.Price == maxTourPrice).Select(y => y.Name).FirstOrDefault().ToString();

			var guideIdByNameAysegulCinar = db.Guides.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y=>y.GuideId).FirstOrDefault();
			lblAysegulCinarLocationCount.Text = db.Locations.Where(x => x.GuideId == guideIdByNameAysegulCinar).Count().ToString();
		}
	}
}
