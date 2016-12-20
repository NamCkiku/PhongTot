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
    public interface IEmailTemplateService
    {
        EmailTemplate Add(EmailTemplate emailteamplate);

        void Update(EmailTemplate emailteamplate);

        EmailTemplate Delete(int id);

        IEnumerable<EmailTemplate> GetAll();

        EmailTemplate GetById(int id);

        void SaveChanges();
    }
    public class EmailTemplateService : IEmailTemplateService
    {
        private readonly IEmailTemplateRepository _emailteamplateRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EmailTemplateService(IEmailTemplateRepository emailteamplateRepository, IUnitOfWork unitOfWork)
        {
            this._emailteamplateRepository = emailteamplateRepository;
            this._unitOfWork = unitOfWork;
        }

        public EmailTemplate Add(EmailTemplate emailteamplate)
        {
            return _emailteamplateRepository.Add(emailteamplate);
        }

        public EmailTemplate Delete(int id)
        {
            return _emailteamplateRepository.Delete(id);
        }

        public IEnumerable<EmailTemplate> GetAll()
        {
            return _emailteamplateRepository.GetAll();
        }

        public EmailTemplate GetById(int id)
        {
            return _emailteamplateRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(EmailTemplate emailteamplate)
        {
            _emailteamplateRepository.Update(emailteamplate);
        }
    }
}
