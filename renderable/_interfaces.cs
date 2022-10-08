namespace Renderable { 
    public interface IRenderable { 
        List<Axel> Render();
    }

    public interface IRenderer { 
        public void AddRenderable(IRenderable ren);
        public void RemoveRenderable(IRenderable ren);
        public List<Axel> CompileRenderables();
    }
}