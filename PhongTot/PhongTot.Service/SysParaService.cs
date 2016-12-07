using PhongTot.Entities.Models;
using PhongTot.Repository.Infrastructure;
using PhongTot.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhongTot.Service
{
    public interface ISysParaService
    {
        SysPara Add(SysPara sysPara);
        IEnumerable<SysPara> GetAll();
        bool UpdateListSystemPara(List<SysPara> lstsysPara);
        void SaveChanges();
    }
    public class SysParaService : ISysParaService
    {
        private readonly ISysParaRepository _sysParaRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SysParaService(ISysParaRepository sysParaRepository, IUnitOfWork unitOfWork)
        {
            this._sysParaRepository = sysParaRepository;
            this._unitOfWork = unitOfWork;
        }
        public SysPara Add(SysPara sysPara)
        {
            return _sysParaRepository.Add(sysPara);
        }

        public IEnumerable<SysPara> GetAll()
        {
            return _sysParaRepository.GetAll();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool UpdateListSystemPara(List<SysPara> lstsysPara)
        {
            bool reSult = false;

            try
            {
                bool bCheck = true;

                foreach (var item in lstsysPara)
                {
                    if (!_sysParaRepository.UpdateSysPara(item.ID, item.Field, item.Value))
                    {
                        bCheck = false;
                        break;
                    }
                }
                if (bCheck)
                {
                    reSult = true;

                }
                else
                {
                    reSult = false;
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
