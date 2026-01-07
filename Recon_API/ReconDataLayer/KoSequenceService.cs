using System.Data;
using ReconDataLayer;
using ReconModels;
using static ReconModels.KoSequenceModel;
using static ReconModels.UserManagementModel;

namespace ReconServiceLayer
{
    public class KoSequenceService
    {
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
        public static DataSet Reconkoseqfetchsrv(Reconkoseqmodellist Reconkoseqmodellist, UserManagementModel.headerValue headerval, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                KoSequenceData objqcd = new KoSequenceData();
                ds = objqcd.Reconkoseqfetchdata(Reconkoseqmodellist, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
        public static DataTable seqlistsrv(seqlistmodel seqlistmodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                KoSequenceData objqcd = new KoSequenceData();
                ds = objqcd.seqlistdata(seqlistmodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
        public DataTable Reconkoseqtreesrv(Reconversiontreemodel Reconversiontreemodel,UserManagementModel.headerValue objmodel, string constring)
        {
            List<treeviewllist> tnl = new List<treeviewllist>();
            DataTable ds = new DataTable();
            try
            {
                KoSequenceData objproduct = new KoSequenceData();
                ds = objproduct.Reconkoseqtree_db(Reconversiontreemodel,objmodel, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
        public static DataSet rowqcdlistsrv(rowqcdlist rowqcdlistmodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                KoSequenceData objqcd = new KoSequenceData();
                ds = objqcd.rowqcdlistData(rowqcdlistmodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
        public static DataTable reconfieldqcdlistsrv(reconfieldqcdlist rowfieldqcdlistmodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                KoSequenceData objqcd = new KoSequenceData();
                ds = objqcd.reconfieldqcdlistData(rowfieldqcdlistmodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable reconexpsavesrv(reconexpsavemodel objreconexpsavemodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                KoSequenceData objqcd = new KoSequenceData();
                ds = objqcd.reconexpsaveData(objreconexpsavemodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable setrecordlocksrv(rowqcdlist rowqcdlistmodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                KoSequenceData objqcd = new KoSequenceData();
                ds = objqcd.setrecordlockData(rowqcdlistmodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataTable setrecordunlocksrv(rowqcdlist rowqcdlistmodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataTable ds = new DataTable();
            try
            {
                KoSequenceData objqcd = new KoSequenceData();
                ds = objqcd.setrecordunlockData(rowqcdlistmodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }

        public static DataSet getrecordlocksrv(rowqcdlist rowqcdlistmodel, UserManagementModel.headerValue headerval, string constring)
        {
            DataSet ds = new DataSet();
            try
            {
                KoSequenceData objqcd = new KoSequenceData();
                ds = objqcd.getrecordlockData(rowqcdlistmodel, headerval, constring);
            }
            catch (Exception e)
            { }
            return ds;
        }
    }
}
