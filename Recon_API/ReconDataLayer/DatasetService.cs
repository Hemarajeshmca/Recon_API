using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReconModels.DatasetModel;

namespace ReconServiceLayer
{
	public class DatasetService
	{
		public static DataTable DatasetRead(Datasetlistmodel Datasetlistmode)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasetData objDS = new DatasetData();
				ds = objDS.DatasetReaddata(Datasetlistmode);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable DatasetHeader(DatasetHeadermodel Datasetheadermodel)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasetData objDS = new DatasetData();
				ds = objDS.DatasetHeaderdata(Datasetheadermodel);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable DatasetDetail(Datasetdetailmodel Datasetheadermodel)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasetData objDS = new DatasetData();
				ds = objDS.DatasetDetaildata(Datasetheadermodel);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable DatasetReaddetail(Datasetdetailmodellist Datasetdetailmodellist)
		{
			DataTable ds = new DataTable();
			try
			{
				DatasetData objDS = new DatasetData();
				ds = objDS.DatasetReaddetaildata(Datasetdetailmodellist);
			}
			catch (Exception e)
			{ }
			return ds;
		}
		public static DataTable getfieldtype()
		{
			DataTable ds = new DataTable();
			try
			{
				DatasetData objDS = new DatasetData();
				ds = objDS.getfieldtype();
			}
			catch (Exception e)
			{ }
			return ds;
		}
	}
}
