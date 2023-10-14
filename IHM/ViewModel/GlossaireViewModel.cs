using System;
using System.Collections.Generic;

namespace IHM.ViewModel
{
    internal class GlossaireViewModel : ObservableObject, IPageViewModel
    {
        #region Fields and Enums

        private readonly List<GlossaireItem> _list = new();

        #endregion

        #region Constructors

        public GlossaireViewModel() {
            _list.Add(
                      new GlossaireItem(
                                        "Base Attack/Life", string.Empty,
                                        "L'attaque et la vie de base de votre personnage. Cette donnée est visible sur l'écran PvP."));
            _list.Add(
                      new GlossaireItem(
                                        "+x% de VIE/ATTAQUE à votre héros", "*",
                                        "Pourcentage d'augmentation de la stat de base. Le total est visible dans le récapitulatif des stats." + Environment.NewLine +
                                        "Cette notion est appelée \"Attack/Life %\" dans l'application."));
            _list.Add(
                      new GlossaireItem(
                                        "+x% de PV à votre héros", "*",
                                        "Equivalent de +x% de VIE à votre héros. VIsible uniquement sur les Runes à scaling. (Surement une typo des devs)"));
            _list.Add(
                      new GlossaireItem(
                                        "DEBUT DE COMBAT : [Effet]", "*",
                                        "Ce mot clé signifie que tout ce qui est indiqué se déroulera au début du combat. Cela à pour effet de changer de catégorie les buffs tel que +x% de VIE à votre héros." + Environment.NewLine +
                                        "Cette catégorie est appelée \"Attack/Life in Battle %\". Ce mot clé n'est pas la seule façon d'obtenir ce genre de bonus !"));
            _list.Add(
                      new GlossaireItem(
                                        "DEBUT DU TOUR : [Effet]", "*",
                                        "Ce mot clé signifie que tout ce qui est indiqué se déroulera au début de votre tour. Cela à pour effet de changer de catégorie les buffs tel que +x% de VIE à votre héros." + Environment.NewLine +
                                        "Cette catégorie est appelée \"Attack/Life in Battle %\". Ce mot clé n'est pas la seule façon d'obtenir ce genre de bonus !"));
            _list.Add(
                      new GlossaireItem(
                                        "Limité à x fois par tour", "*",
                                        "Bien que simple, il reste important de définir un \"tour\". Dans Waven, un tour de table fini à la fin de votre tour de jeu et inclus le temps de jeu des adversaires et, si applicable, de vos alliés." + Environment.NewLine +
                                        "Ainsi un effet limité à 2 fois peut être déclencher 2 fois à partir de la fin de votre tour (quand vous faites \"Fin de tour\") et jusqu'à la fin de votre prochaine fin de tour."));
            _list.Add(
                      new GlossaireItem(
                                        "+x% aux chances de COUP CRITIQUE de votre héros.", "*",
                                        "Les probabilités de faire un coup critique avec l'attaque du héros. 5% de base."));
            _list.Add(
                      new GlossaireItem(
                                        "+x% chances de COUP CRITIQUE aux sorts.", "*",
                                        "Les probabilités de faire un coup critique avec les sorts. 5% de base. (Non visible dans les stats)"));
            _list.Add(
                      new GlossaireItem(
                                        "+x% de DEGATS CRITIQUE à votre héros.", "*",
                                        "Pourcentage d'augmentation des dégâts critique infligés. 50% de base. (Non visible dans les stats)" + Environment.NewLine +
                                        "Ce multiplicateur n'affecte pas les sorts. (A vérifier pour l'armure et autre effet style Licorno)"));
            _list.Add(
                      new GlossaireItem(
                                        "Chaine d'effet", string.Empty,
                                        "Un concept simple mais important. Si la source d'un effet est critique, alors cet effet sera (si possible) critique." + Environment.NewLine +
                                        "Exemple : Si un sort à une rune \"CRITIQUE : Déclenche Rebond (x)\" ce Rebond sera forcément un coup critique, car le sort qui l'a déclenché est critique (puisque c'est la condition pour que le rebond ai lieu)"));
            _list.Add(
                      new GlossaireItem(
                                        "CRITIQUE : [Effet]", "*",
                                        "Déclenche l'effet si l'action est un coup critique. Déclenche une chaine d'effet."));
            _list.Add(
                      new GlossaireItem(
                                        "ATTAQUE : [Effet]", "*",
                                        "Déclenche l'effet quand le héros attaque. Déclenche une chaine d'effet."));
            _list.Add(
                      new GlossaireItem(
                                        "+x% de DRAIN à votre héros.", "*",
                                        "Régénère un pourcentage de l'attaque quand le héros attaque. Bien que rattachée à l'attaque, cette valeur est fixe et ne peux pas crit ni être réduite."));
            _list.Add(
                      new GlossaireItem(
                                        "VOL DE VIE", "*",
                                        "Soigne le personnage d'un montant égal aux dégâts infligés aux PV de l'adversaire. L'armure (AR) est donc un contre naturel à cette mécanique."));
        }

        #endregion

        #region Properties

        public IEnumerable<GlossaireItem> ItemList => _list;

        #endregion

        #region IPageViewModel Members

        public string Name => "Glossaire";

        #endregion
    }

    internal record GlossaireItem(string Name, string Asterisk, string Description) { }
}