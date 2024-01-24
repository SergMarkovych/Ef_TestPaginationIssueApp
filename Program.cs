using Ef_TestPaginationIssueApp.Data;
using Ef_TestPaginationIssueApp.Types;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

using var _context = new AppDbContext();
_context.Database.EnsureCreated();
_context.EnsureSeedData();

try
{
    var parentDtos = GetParentDtos();
}
catch (Exception ex)
{
    throw ex;
}

List<ParentDto> GetParentDtos()
{
    IQueryable<ParentDto> parentDto = _context.Parent.Include(x => x.Child)
        .Select
        (
            x => new ParentDto
            {
                ParentId = x.Id,
                SomeValue1 = x.Child.InfoData.Fields.FirstOrDefault(x => x.Code == "Total").Value,
                SomeValue2 = x.Child.InfoData.Fields.FirstOrDefault(x => x.Code == "Total2").Value,
                CalculatedValue = x.Child.InfoData.Fields.FirstOrDefault(x => x.Code == "Total").Value - x.Child.InfoData.Fields.FirstOrDefault(x => x.Code == "Total2").Value,
                CalculatedValue2 = x.Child.InfoData.Fields.FirstOrDefault(x => x.Code == "Total2").Value - x.Child.InfoData.Fields.FirstOrDefault(x => x.Code == "Total").Value,
                FullNumber = x.Phone.FullNumber
            }
        );

    var result1 = parentDto.OrderBy(x => x.CalculatedValue2).Skip(25).Take(10);
    var result = parentDto.OrderBy(x => x.CalculatedValue2).Skip(25).Take(10).ToList();

    return result;
}