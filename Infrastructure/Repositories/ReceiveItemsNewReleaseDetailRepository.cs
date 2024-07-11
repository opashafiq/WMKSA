using Application.Abstractions;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ReceiveItemsNewReleaseDetailRepository : IReceiveItemsNewReleaseDetailRepository
    {
        private readonly ApplicationDBContext _context;

        public ReceiveItemsNewReleaseDetailRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ReceiveItemsNewReleaseDetail> AddReceiveItemsNewReleaseDetail(ReceiveItemsNewReleaseDetail toCreate)
        {
            _context.ReceiveItemsNewReleaseDetails.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<ReceiveItemsNewReleaseDetail> DeleteReceiveItemsNewReleaseDetail(int personId)
        {
            var receiveItemsNewReleaseDetail = _context.ReceiveItemsNewReleaseDetails
                .FirstOrDefault(p => p.Id == personId);

            if (receiveItemsNewReleaseDetail is null)
            {
                throw new Exception("Nothing Found For Deletion");
                //return person;
            }

            _context.ReceiveItemsNewReleaseDetails.Remove(receiveItemsNewReleaseDetail);

            await _context.SaveChangesAsync();
            return receiveItemsNewReleaseDetail;

        }



        public async Task<ICollection<ReceiveItemsNewReleaseDetail>> GetAll()
        {
            return await _context.ReceiveItemsNewReleaseDetails.ToListAsync();
        }

        public async Task<ReceiveItemsNewReleaseDetail> GetReceiveItemsNewReleaseDetailById(int receiveItemsNewReleaseDetailId)
        {
            return await _context.ReceiveItemsNewReleaseDetails.FirstOrDefaultAsync(p => p.Id == receiveItemsNewReleaseDetailId)??new ReceiveItemsNewReleaseDetail();
        }

        public async Task<ReceiveItemsNewReleaseDetail> UpdateReceiveItemsNewReleaseDetail(ReceiveItemsNewReleaseDetail toUpdate )
        {
            _context.ReceiveItemsNewReleaseDetails.Update(toUpdate);

            await _context.SaveChangesAsync();

            return toUpdate;
        }
    }
}
