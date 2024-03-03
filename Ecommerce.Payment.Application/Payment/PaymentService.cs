using AutoMapper;
using Ecommerce.Payment.Application.Payment.Dto;
using Ecommerce.Payment.Application.Shared;
using Ecommerce.Payment.Domain.Entity.Payment.Repository;
using Ecommerce.Payment.Domain.Entity.Readonly.Repository;

namespace Ecommerce.Payment.Application.Payment
{
    //public class PaymentService : IPaymentService
    public class PaymentService : AbstractService, IPaymentService
    {
        private readonly IPaymentRepository _PaymentRepository;
        private readonly IReadonlyRepository _readonlyRepository;

        public PaymentService(IPaymentRepository PaymentRepository, IMapper mapper, IReadonlyRepository readonlyRepository)
            : base(mapper)
        {
            _PaymentRepository = PaymentRepository;
            //_mapper = mapper;
            _readonlyRepository = readonlyRepository;
        }
        public async Task<PaymentDto> GetPayment(int PaymentId)
        {
            var result = await _PaymentRepository.GetOneByCriteria(a => a.Id == PaymentId);
            return _mapper.Map<PaymentDto>(result);
        }
        public async Task<List<PaymentDto>> GetAllPayments()
        {
            var result = await _readonlyRepository.GetAllPayment();
            return _mapper.Map<List<PaymentDto>>(result);
        }

        //public async Task<PaymentDto> SavePayment(PaymentDto PaymentDto)
        //{
        //    var entity = _mapper.Map<Ecommerce.Payment.Domain.Entity.Payment.Payment>(PaymentDto);
        //    try
        //    {
        //        if (PaymentDto.Id > 0)
        //            await _PaymentRepository.Update(entity);
        //        else
        //            await _PaymentRepository.Save(entity);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.InnerException != null)
        //            throw ex.InnerException;
        //        throw;
        //    }
        //    return _mapper.Map<PaymentDto>(entity);
        //}
        public async Task<PaymentDto> SavePayment(PaymentDto PaymentDto)
        {
            using (var transaction = await _PaymentRepository.CreateTransaction())
            {
                try
                {
                    //if (!PaymentDto.Created.HasValue)
                    //    Created.Created = DateTime.Now;

                    var result = await SaveUpdateDeleteDto(PaymentDto, _PaymentRepository);

                    await transaction.CommitAsync();

                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
        public async Task<bool> DeletePayment(int PaymentdId)
        {
            using (var transaction = await _PaymentRepository.CreateTransaction())
            {
                try
                {
                    var Payment = await _PaymentRepository.GetOneByCriteria(a => a.Id == PaymentdId);

                    await _PaymentRepository.Delete(Payment);

                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
        }
    }
}
