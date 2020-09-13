using ODataSamples.Domain;
using ODataSamples.Domain.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataSamples.Dtos
{
    public class PageListDto<TDto>
    {
        private PageListDto() { }

        public Pagination Pagination { get; private set; }
        public IEnumerable<TDto> Results  { get; private set; }

        public static PageListDto<TDto> Map<TEntity>(PageList<TEntity> entities, Func<TEntity, TDto> mapDomainToDto)
            where TEntity : Identity<TEntity>
        {
            var pagination = new Pagination(entities.PageIndex, entities.TotalPages, entities.TotalCount, entities.HasPreviousPage, entities.HasNextPage);
            var pageListDto = new PageListDto<TDto>
            {
                Pagination = pagination,
                Results = entities.Select(e => mapDomainToDto(e))
            };
            return pageListDto;
        }
    }

    public class Pagination
    {
        public Pagination(int pageIndex, int totalPages, int totalCount, bool hasPreviousPage, bool hasNextPage)
        {
            PageIndex = pageIndex;
            TotalPages = totalPages;
            TotalCount = totalCount;
            HasPreviousPage = hasPreviousPage;
            HasNextPage = hasNextPage;
        }

        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }

        public bool HasPreviousPage { get; private set; }
        public bool HasNextPage { get; private set; }
    }
}
