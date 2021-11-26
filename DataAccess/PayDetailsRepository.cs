using PAYE.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAYE.API.DataAccess
{
    public class PayDetailsRepository : IFirestore<PayDetails>
    {
        private string collectionName = "PayDetails";
        private BaseRepository baseRepository;

        public PayDetailsRepository()
        {
            baseRepository = new BaseRepository(collectionName);
        }

        public PayDetails Add(PayDetails record)
        {
            return baseRepository.Add(record);
        }

        public bool Delete(PayDetails record)
        {
            return baseRepository.Delete(record);
        }

        public PayDetails Get(PayDetails record)
        {
            return baseRepository.Get(record);
        }

        public PayDetails GetById(string Id)
        {
            return baseRepository.Get<PayDetails>(Id);
        }

        public List<PayDetails> GetAll()
        {
            return baseRepository.GetAll<PayDetails>();
        }

        public bool Update(PayDetails record)
        {
            return baseRepository.Update(record);
        }

        public PayDetails GetByPayMonth(string PhoneNumber, string PayMonth, int PayYear)
        {
            var allPayDetails = baseRepository.GetAll<PayDetails>();
            var payDetails = allPayDetails?.First(pd => pd.PhoneNumber == PhoneNumber && pd.PayMonth == PayMonth && pd.PayYear == PayYear);

            if (payDetails != null)
                return payDetails;

            return null;
        }

        public List<PayDetails> GetByPhoneNumber(string PhoneNumber)
        {
            var allPayDetails = baseRepository.GetAll<PayDetails>();
            var payDetails = allPayDetails?.Where(pd => pd.PhoneNumber == PhoneNumber);

            if (payDetails != null)
                return payDetails.ToList();

            return null;
        }

        public List<PayDetails> GetByPayYear(string PhoneNumber, int PayYear)
        {
            var allPayDetails = baseRepository.GetAll<PayDetails>();
            var payDetails = allPayDetails?.Where(pd => pd.PhoneNumber == PhoneNumber && pd.PayYear == PayYear);

            if (payDetails != null)
                return payDetails.ToList();

            return null;
        }
    }
}
