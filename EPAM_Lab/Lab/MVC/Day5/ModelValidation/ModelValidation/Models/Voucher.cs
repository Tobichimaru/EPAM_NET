using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace ModelValidation.Models
{
	public class Voucher
	{

		public string Name { get; set; }
		public string Prefix { get; set; }
		public string Postfix { get; set; }
		public decimal? MinimalAmount { get; set; }
		public decimal? Percentage { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public bool SingleUse { get; set; }
		public string Title
		{
			get
			{
				return string.Format("Voucher {0}", 
					string.Format("{0} {1} {2}", Prefix, Name, Postfix)
					.Trim().Replace(' ','_'));
			}
		}
	}
}