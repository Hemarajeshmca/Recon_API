using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReconDataLayer;
using ReconModels;
using static ReconModels.KoSequenceModel;

namespace ReconServiceLayer
{
    public class KoSequenceService
    {
        public static DataTable getseqtype(koseqmodel objkoseqmodel,UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                KoSequenceData objqcd = new KoSequenceData();
                ds = objqcd.getseqtypeData(objkoseqmodel,headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable KoSequenceSavesrv(koseqsavemodel objkoseqsavemodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                KoSequenceData objqcd = new KoSequenceData();
                ds = objqcd.KoSequenceSaveData(objkoseqsavemodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
        public static DataTable seqlistfetchsrv(koseqlistmodel objkoseqlistmodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                KoSequenceData objqcd = new KoSequenceData();
                ds = objqcd.seqlistfetchData(objkoseqlistmodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
    }
}
