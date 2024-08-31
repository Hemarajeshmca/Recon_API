﻿using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.UpdateReconModel;


namespace ReconServiceLayer
{
	public class UpdateReconService
	{
		public static DataTable ReconUpdateRuleService(ReconUpdateRuleModel objReconUpdateRule, UserManagementModel.headerValue headerval, string constring)
		{
			DataTable ds = new DataTable();
			try
			{
				UpdateReconData objqcd = new UpdateReconData();
				ds = objqcd.ReconUpdateRuleData(objReconUpdateRule, headerval, constring);
			}
			catch (Exception e)
			{ }
			return ds;
		}


	}
}
