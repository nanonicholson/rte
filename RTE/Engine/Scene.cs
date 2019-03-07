﻿using System.Collections.Generic;
using System;
using OpenTK.Graphics;
using System.Linq;

namespace RTE.Engine
{
    class Scene
    {
        public readonly string Name;
        public readonly Dictionary<string, Actor> Actors;

        private readonly SceneRenderer sceneRenderer;

        public Scene(string name)
        {
            Name = name;
            Actors = new Dictionary<string, Actor>();

            sceneRenderer = new SceneRenderer(this)
                .SetBackgroundColor(Color4.DarkSalmon);
        }

        public void Draw()
        {
            sceneRenderer.Draw(Actors.Values.ToArray());
        }

        public Scene AddActor(Actor actor)
        {
            Actors.Add(actor.Name, actor);

            return this;
        }

        public bool RemoveActor(string name)
        {
            return Actors.Remove(name);
        }

        public Actor GetActor(string name)
        {
            if (!Actors.TryGetValue(name, out Actor result))
                throw new Exception($"Scene does not contain actor '{name}'");

            return result;
        }
    }
}