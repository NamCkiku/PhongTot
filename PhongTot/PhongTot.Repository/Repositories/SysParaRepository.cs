using PhongTot.Common;
using PhongTot.Entities.Models;
using PhongTot.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongTot.Repository.Repositories
{
    public interface ISysParaRepository : IRepository<SysPara>
    {
        bool UpdateSysPara(int Id, string sField, string sValue);
    }
    public class SysParaRepository : RepositoryBase<SysPara>, ISysParaRepository
    {
        public SysParaRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
        public bool UpdateSysPara(int Id, string sField, string sValue)
        {
            SysPara oSysPara = new SysPara();
            bool reSult = false;
            try
            {
                oSysPara = DbContext.SysParas.Where(x => x.Field.Trim() == sField.Trim()).FirstOrDefault();

                if (oSysPara != null)
                {
                    if (oSysPara.Value.Trim() != sValue.Trim())
                    {
                        oSysPara.Value = sValue;
                    }
                    else
                    {
                        reSult = true;
                    }
                }
                else
                {
                    oSysPara = new SysPara();
                    oSysPara.Field = sField;
                    oSysPara.Value = sValue;
                    if (
                        !(sField == Var.RwSearchFilter)
                        )

                    DbContext.SysParas.Add(oSysPara);
                }

                int iResult = DbContext.SaveChanges();
                if (iResult >= 0)
                {
                    reSult = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reSult;
        }
    }
}
