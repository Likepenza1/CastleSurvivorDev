using System;
using System.Collections.Generic;
using Descriptions.Core;
using Descriptions.Items;
using Descriptions.Main;
using Descriptions.Stage;
using Descriptions.Units;
using Descriptions.Upgrades;
using MessagePack;
using builder = Descriptions.Core.DescriptionCollectionBuilder;

namespace Descriptions
{
    [MessagePackObject(true)]
    public class GameRules
    {
        public ServerDescription ServerDescription;
        public AppearanceDescription AppearanceDescription;
        public StagesSequenceDescription StagesSequence;
        public ScenesDescription Scenes;
        public PlayerDescription Player;
        
        public IReadOnlyDictionary<string, ItemDescription> Items;
        public IReadOnlyDictionary<string, ResourceDescription> Resources;
        public IReadOnlyDictionary<string, UpgradeDescription> Upgrades;
        public IReadOnlyDictionary<string, StageDescription> Stages;
        public IReadOnlyDictionary<string, UnitDescription> Units;

        public void Build()
        {
            ServerDescription = builder.Build(new SingleJsonDescriptionGenerator<ServerDescription>("Server").Generate());
            AppearanceDescription = builder.Build(new SingleJsonDescriptionGenerator<AppearanceDescription>("Appearance").Generate());
            StagesSequence = builder.Build(new SingleJsonDescriptionGenerator<StagesSequenceDescription>("StagesSequence").Generate());
            Scenes = builder.Build(new SingleJsonDescriptionGenerator<ScenesDescription>("Scenes").Generate());
            Player = builder.Build(new SingleJsonDescriptionGenerator<PlayerDescription>("Player").Generate());
            
            Items = builder.Build(new JsonDescriptionGenerator<ItemDescription>("Items").Generate());
            Resources = builder.Build(new JsonDescriptionGenerator<ResourceDescription>("Resources").Generate());
            Upgrades = builder.Build(new JsonDescriptionGenerator<UpgradeDescription>("Upgrades").Generate());
            Stages = builder.Build(new JsonDescriptionGenerator<StageDescription>("Stages").Generate());
            Units = builder.Build(new JsonDescriptionGenerator<UnitDescription>("Units").Generate());
        }
    }
}