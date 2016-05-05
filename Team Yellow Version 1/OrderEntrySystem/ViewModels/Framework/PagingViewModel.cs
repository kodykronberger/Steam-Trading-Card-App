using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderEntryEngine;
using OrderEntrySystem.Utilities;

namespace OrderEntrySystem
{
    /// <summary>
    /// The class which is used to represent a paging view model.
    /// </summary>
    public class PagingViewModel : ViewModel
    {
        /// <summary>
        /// The total item count.
        /// </summary>
        private int itemCount;

        /// <summary>
        /// The size of the page.
        /// </summary>
        private int pageSize;

        /// <summary>
        /// The current page number.
        /// </summary>
        private int currentPage;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="itemCount">The total item count.</param>
        public PagingViewModel(int itemCount)
            : base(string.Empty)
        {
            Contract.Requires(itemCount >= 0);
            Contract.Requires(this.pageSize > 0);
            this.itemCount = itemCount;
            this.pageSize = 3;
            this.currentPage = this.itemCount == 0 ? 0 : 1;
            this.GoToFirstPageCommand = new DelegateCommand(p => this.CurrentPage = 1, p => this.ItemCount > 0 && this.CurrentPage > 1);
            this.GoToPreviousPageCommand = new DelegateCommand(p => this.CurrentPage--, p => this.ItemCount > 0 && this.CurrentPage > 1);
            this.GoToNextPageCommand = new DelegateCommand(p => this.CurrentPage++, p => this.ItemCount > 0 && this.CurrentPage < this.PageCount);
            this.GoToLastPageCommand = new DelegateCommand(p => this.CurrentPage = this.PageCount, p => this.ItemCount > 0 && this.CurrentPage < this.PageCount);
        }

        /// <summary>
        /// The event handler for when the current page changes.
        /// </summary>
        public event EventHandler<CurrentPageChangedEventArgs> CurrentPageChanged;

        /// <summary>
        /// Gets or sets the total item count.
        /// </summary>
        public int ItemCount
        {
            get
            {
                return this.itemCount;
            }
            set
            {
                this.itemCount = value;
                this.OnPropertyChanged("ItemCount");
                this.OnPropertyChanged("PageSize");
            }
        }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        public int PageSize
        {
            get
            {
                return this.pageSize;
            }
            set
            {
                this.pageSize = value;
                this.OnPropertyChanged("PageSize");
                this.OnPropertyChanged("PageCount");
            }
        }

        /// <summary>
        /// Gets the number of pages.
        /// </summary>
        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling((double)this.itemCount / this.pageSize);
            }
        }

        /// <summary>
        /// Gets or sets the current page number.
        /// </summary>
        public int CurrentPage
        {
            get
            {
                return this.currentPage;
            }
            set
            {
                this.currentPage = value;
                this.OnPropertyChanged("CurrentPage");
                EventHandler<CurrentPageChangedEventArgs> handler = this.CurrentPageChanged;

                if (handler != null)
                {
                    handler(this, new CurrentPageChangedEventArgs(this.CurrentPageStartIndex, this.PageSize));
                }
            }
        }

        /// <summary>
        /// Gets the current page's starting index.
        /// </summary>
        public int CurrentPageStartIndex
        {
            get
            {
                return this.PageCount == 0 ? -1 : (this.CurrentPage - 1) * this.PageSize;
            }
        }

        /// <summary>
        /// Gets or sets the go-to first page command.
        /// </summary>
        public DelegateCommand GoToFirstPageCommand { get; set; }

        /// <summary>
        /// Gets or sets the go-to previous page command.
        /// </summary>
        public DelegateCommand GoToPreviousPageCommand { get; set; }

        /// <summary>
        /// Gets or sets the go-to next page command.
        /// </summary>
        public DelegateCommand GoToNextPageCommand { get; set; }

        /// <summary>
        /// Gets or sets the go-to last page command.
        /// </summary>
        public DelegateCommand GoToLastPageCommand { get; set; }
    }
}