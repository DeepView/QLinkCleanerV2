using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLinkCleanerV2.Core
{
    public class Manifest : ICollection<ListData>, IReadOnlyCollection<ListData>, IEnumerable<ListData>, IEnumerable, IList<ListData>, IReadOnlyList<ListData>
    {
        private List<ListData> _dataContainer;      //数据容器，使用 List<ListData> 作为基础数据结构。
        /// <summary>
        /// 创建一个空的清单实例。
        /// </summary>
        public Manifest() => _dataContainer = [];
        public string? Name { get; set; }
        /// <summary>
        /// 保存清单到指定的文件路径。
        /// </summary>
        /// <param name="filePath">指定的文件路径。</param>
        public void Save(string filePath)
        {
            using StreamWriter writer = new(filePath, false, Encoding.UTF8);
            foreach (var item in _dataContainer) writer.WriteLine(item);
        }
        /// <summary>
        /// 解析指定路径的文件内容，并将其转换为清单数据。
        /// </summary>
        /// <param name="filePath">指定的清单文件路径。</param>
        /// <exception cref="FileNotFoundException">当文件不存在时，则将会抛出这个异常。</exception>
        public void Parse(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException("指定的文件不存在。", filePath);
            _dataContainer.Clear();
            using StreamReader reader = new(filePath, Encoding.UTF8);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line)) continue; // 跳过空行
                _dataContainer.Add(ListData.Parse(line.Trim()));
            }
        }
        public ListData this[int index]
        {
            get => ((IList<ListData>)_dataContainer)[index];
            set => ((IList<ListData>)_dataContainer)[index] = value;
        }
        public int Count => ((ICollection<ListData>)_dataContainer).Count;
        public bool IsReadOnly => ((ICollection<ListData>)_dataContainer).IsReadOnly;
        public void Add(ListData item) => ((ICollection<ListData>)_dataContainer).Add(item);
        public void Clear() => ((ICollection<ListData>)_dataContainer).Clear();
        public bool Contains(ListData item) => ((ICollection<ListData>)_dataContainer).Contains(item);
        public void CopyTo(ListData[] array, int arrayIndex) => ((ICollection<ListData>)_dataContainer).CopyTo(array, arrayIndex);
        public IEnumerator<ListData> GetEnumerator() => ((IEnumerable<ListData>)_dataContainer).GetEnumerator();
        public int IndexOf(ListData item) => ((IList<ListData>)_dataContainer).IndexOf(item);
        public void Insert(int index, ListData item) => ((IList<ListData>)_dataContainer).Insert(index, item);
        public bool Remove(ListData item) => ((ICollection<ListData>)_dataContainer).Remove(item);
        public void RemoveAt(int index) => ((IList<ListData>)_dataContainer).RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_dataContainer).GetEnumerator();
    }
}
