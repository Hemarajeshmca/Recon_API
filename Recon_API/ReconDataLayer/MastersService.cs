using ReconDataLayer;
using ReconModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconServiceLayer
{
    public class MastersService
    {
        MastersData MastersData = new MastersData();
        DataTable dt = new DataTable();

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(MastersService));
        List<Dictionary<string, object>> returnObjForFetch = new List<Dictionary<string, object>>();

        public DataSet Reconfieldmapping(Reconfieldmapping reconfieldmapping)
        {
            try
            {
                DataSet ds = MastersData.Reconfieldmapping(reconfieldmapping);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Recon(Recon recon)
        {
            try
            {
                DataSet ds = MastersData.Recon(recon);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Reconacc(Reconacc reconacc)
        {
            try
            {
                DataSet ds = MastersData.Reconacc(reconacc);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Reconfield(Reconfield reconfield)
        {
            try
            {
                DataSet ds = MastersData.Reconfield(reconfield);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Acc(Acc acc)
        {
            try
            {
                DataSet ds = MastersData.Acc(acc);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Reconfiletemplate(Reconfiletemplate reconfiletemplate)
        {
            try
            {
                DataSet ds = MastersData.Reconfiletemplate(reconfiletemplate);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Mstrule(Mstrule mstrule)
        {
            try
            {
                DataSet ds = MastersData.Mstrule(mstrule);
                return ds;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Filetemplatefield(Filetemplatefield filetemplatefield)
        {
            try
            {
                DataSet ds = MastersData.Filetemplatefield(filetemplatefield);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Filetemplate(Filetemplate filetemplate)
        {
            try
            {
                DataSet ds = MastersData.Filetemplate(filetemplate);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Rulefield(Rulefield rulefield)
        {
            try
            {
                DataSet ds = MastersData.Rulefield(rulefield);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Applyrule(Applyrule applyrule)
        {
            try
            {
                DataSet ds = MastersData.Applyrule(applyrule);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Applyruledtl(Applyruledtl applyruledtl)
        {
            try
            {
                DataSet ds = MastersData.Applyruledtl(applyruledtl);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Applyrule_addcond(Applyrule_addcond Applyruleaddcond)
        {
            try
            {
                DataSet ds = MastersData.Applyrule_addcond(Applyruleaddcond);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Applyrule_targetgrpfield(Applyrule_targetgrpfield applyruletargetgrpfield)
        {
            try
            {
                DataSet ds = MastersData.Applyrule_targetgrpfield(applyruletargetgrpfield);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Applyrule_basesele(Applyrule_basesele applyrulebasesele)
        {
            try
            {
                DataSet ds = MastersData.Applyrule_basesele(applyrulebasesele);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Applyrule_basefilter(Applyrule_basefilter applyrulebaseselefilter)
        {
            try
            {
                DataSet ds = MastersData.Applyrule_basefilter(applyrulebaseselefilter);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
