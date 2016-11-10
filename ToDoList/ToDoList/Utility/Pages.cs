using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Utility
{
    public class PageViewData
    {
        /// 

        /// 当前页
        /// 

        public int CurrentPage { get; set; }

        private readonly int _totalPageount;
        /// 

        /// 总页数
        /// 

        public int TotalPageCount
        {
            get
            {
                return _totalPageount;
            }
        }

        private int _totalDataCount;
        /// 

        /// 数据源总量
        /// 

        public int TotalDataCount
        {
            get { return _totalDataCount; }
            set { _totalDataCount = value; }
        }

        private int _pageSize;
        /// 

        /// 每页显示数据大小
        /// 

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        /// 

        /// 当前页数据列表
        /// 

        public IList Items { get; set; }

        public PageViewData()
        {
        }

        public PageViewData(int currentPage, int pageSize, int totalDataCount)
        {
            CurrentPage = currentPage;
            _pageSize = pageSize;
            _totalDataCount = totalDataCount;
            _totalPageount = (int)Math.Ceiling(_totalDataCount * 1.0 / _pageSize);
        }

    }
}