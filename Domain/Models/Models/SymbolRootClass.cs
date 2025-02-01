using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Models
{
    public class SymbolRootClass
    {
            public string lva { get; set; }
            public string lvc { get; set; }
            public double eps { get; set; }
            public string pe { get; set; }
            public double pmd { get; set; }
            public double pmo { get; set; }
            public double qtj { get; set; }
            public double pdv { get; set; }
            public double ztt { get; set; }
            public double qtc { get; set; }
            public double bv { get; set; }
            public double pc { get; set; }
            public double pcpc { get; set; }
            public double pmn { get; set; }
            public double pmx { get; set; }
            public double py { get; set; }
            public double pf { get; set; }
            public double pcl { get; set; }
            public int vc { get; set; }
            public string csv { get; set; }
            public string insID { get; set; }
            public double pMax { get; set; }
            public int pMin { get; set; }
            public double ztd { get; set; }
            public List<BlD> blDs { get; set; }
            public int id { get; set; }
            public string insCode { get; set; }
            public int dEven { get; set; }
            public int hEven { get; set; }
            public double pClosing { get; set; }
            public bool iClose { get; set; }
            public bool yClose { get; set; }
            public double pDrCotVal { get; set; }
            public double zTotTran { get; set; }
            public double qTotTran5J { get; set; }
            public double qTotCap { get; set; }

        public class BlD
        {
            public int n { get; set; }
            public int qmd { get; set; }
            public int zmd { get; set; }
            public double pmd { get; set; }
            public double pmo { get; set; }
            public int zmo { get; set; }
            public int qmo { get; set; }
            public object rid { get; set; }
        }

    }
}
