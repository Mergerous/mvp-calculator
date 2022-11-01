using Scripts.Interfaces;
using UnityEngine.UIElements;

namespace Scripts.Views
{
    public abstract class View : IView
    {
        private readonly UIDocument _document;
        private readonly VisualTreeAsset _asset;
        protected readonly TemplateContainer _container;
        
        protected View(UIDocument document, VisualTreeAsset asset)
        {
            _document = document;
            _asset = asset;
            _container = _asset.CloneTree();
            _container.style.flexGrow = 1;
        }

        public virtual void Open() => _document.rootVisualElement.Add(_container);
        public virtual void Close() => _container.RemoveFromHierarchy();
    }
}