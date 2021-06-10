/*==============================================================*/
/* Nom de SGBD :  MySQL 5.0                                     */
/* Date de création :  09/06/2021 15:47:04                      */
/*==============================================================*/


drop table if exists Anomalie;

drop table if exists Composition;

drop table if exists CompositionTerrain;

drop table if exists CompositionTerrainFavori;

drop table if exists DemandeDeReservation;

drop table if exists Espece;

drop table if exists EvaluationPrestation;

drop table if exists HauteurHerbe;

drop table if exists HauteurHerbeFavori;

drop table if exists HumiditeTerrain;

drop table if exists HumiditeTerrainFavori;

drop table if exists MoyenPaiement;

drop table if exists OffreDeTonte;

drop table if exists PenteTerrain;

drop table if exists PenteTerrainFavori;

drop table if exists PointageJournalier;

drop table if exists RaceAnimal;

drop table if exists RaisonAnnulationDemande;

drop table if exists RaisonAnnulationOffre;

drop table if exists RaisonAnnulationPrematuree;

drop table if exists RaisonDesinscriptionUtilisateur;

drop table if exists RaisonRefusDemande;

drop table if exists RaisonRetraitTerrain;

drop table if exists Terrain;

drop table if exists TypeAnomalie;

drop table if exists TypeVegetation;

drop table if exists TypeVegetationFavori;

drop table if exists Utilisateur;

drop table if exists VilleCP;

/*==============================================================*/
/* Table : Anomalie                                             */
/*==============================================================*/
create table Anomalie
(
   id_anomalie          int not null,
   id_demande           int not null,
   id_utilisateur       int,
   Uti_id_utilisateur   int,
   id_type_anomalie     int not null,
   description_anomalie varchar(254),
   date_declenchement_anomalie datetime,
   date_fin_anomalie    datetime,
   primary key (id_anomalie)
);

/*==============================================================*/
/* Table : Composition                                          */
/*==============================================================*/
create table Composition
(
   id_type_vegetation   int not null,
   id_terrain           int not null,
   pourcentage_vegetation int,
   primary key (id_type_vegetation, id_terrain)
);

/*==============================================================*/
/* Table : CompositionTerrain                                   */
/*==============================================================*/
create table CompositionTerrain
(
   id_composition_terrain int not null,
   composition_terrain  varchar(254),
   primary key (id_composition_terrain)
);

/*==============================================================*/
/* Table : CompositionTerrainFavori                             */
/*==============================================================*/
create table CompositionTerrainFavori
(
   id_composition_terrain int not null,
   id_espece_animal     int not null,
   primary key (id_composition_terrain, id_espece_animal)
);

/*==============================================================*/
/* Table : DemandeDeReservation                                 */
/*==============================================================*/
create table DemandeDeReservation
(
   id_demande           int not null,
   id_raison_annul_prem int,
   id_terrain           int not null,
   id_raison_annul      int,
   id_offre_tonte       int not null,
   id_motif_refus       int,
   id_moyen_paiement    int,
   date_debut_demande   datetime,
   date_fin_demande     datetime,
   cout_demande         numeric(8,0),
   date_acceptaion_demande datetime,
   date_annulation_demande datetime,
   date_creation_demande datetime,
   date_installation_troupeau datetime,
   date_annulation_prematuree datetime,
   numero_reservation   int,
   date_refus_demande   datetime,
   primary key (id_demande)
);

/*==============================================================*/
/* Table : Espece                                               */
/*==============================================================*/
create table Espece
(
   id_espece_animal     int not null,
   espece_animal        varchar(254),
   primary key (id_espece_animal)
);

/*==============================================================*/
/* Table : EvaluationPrestation                                 */
/*==============================================================*/
create table EvaluationPrestation
(
   id_eval_prestation   int not null,
   id_utilisateur       int,
   id_demande           int,
   Uti_id_utilisateur   int,
   note_prestation      int,
   remarque_eval        int,
   primary key (id_eval_prestation)
);

/*==============================================================*/
/* Table : HauteurHerbe                                         */
/*==============================================================*/
create table HauteurHerbe
(
   id_hauteur_herbe     int not null,
   hauteur_herbe        varchar(254),
   primary key (id_hauteur_herbe)
);

/*==============================================================*/
/* Table : HauteurHerbeFavori                                   */
/*==============================================================*/
create table HauteurHerbeFavori
(
   id_hauteur_herbe     int not null,
   id_espece_animal     int not null,
   primary key (id_hauteur_herbe, id_espece_animal)
);

/*==============================================================*/
/* Table : HumiditeTerrain                                      */
/*==============================================================*/
create table HumiditeTerrain
(
   id_humidite_terraine int not null,
   humidite_terrain     varchar(254),
   primary key (id_humidite_terraine)
);

/*==============================================================*/
/* Table : HumiditeTerrainFavori                                */
/*==============================================================*/
create table HumiditeTerrainFavori
(
   id_humidite_terraine int not null,
   id_espece_animal     int not null,
   primary key (id_humidite_terraine, id_espece_animal)
);

/*==============================================================*/
/* Table : MoyenPaiement                                        */
/*==============================================================*/
create table MoyenPaiement
(
   id_moyen_paiement    int not null,
   type_moyen_paiement  varchar(254),
   primary key (id_moyen_paiement)
);

/*==============================================================*/
/* Table : OffreDeTonte                                         */
/*==============================================================*/
create table OffreDeTonte
(
   id_offre_tonte       int not null,
   id_race_animal       int not null,
   id_annulation_offre  int,
   id_utilisateur       int not null,
   id_villeCP           int not null,
   nom_offre            varchar(254),
   adresse_troupeau     varchar(254),
   date_debut_offre     datetime,
   date_fin_offre       datetime,
   date_creation_offre  datetime,
   Description_offre    varchar(254),
   distance_maximale    int,
   cout_anilmal_par_jour numeric(8,0),
   date_annulation_offre datetime,
   nombre_animaux       int,
   primary key (id_offre_tonte)
);

/*==============================================================*/
/* Table : PenteTerrain                                         */
/*==============================================================*/
create table PenteTerrain
(
   id_pente_terrain     int not null,
   pente_terrain        varchar(254),
   primary key (id_pente_terrain)
);

/*==============================================================*/
/* Table : PenteTerrainFavori                                   */
/*==============================================================*/
create table PenteTerrainFavori
(
   id_pente_terrain     int not null,
   id_espece_animal     int not null,
   primary key (id_pente_terrain, id_espece_animal)
);

/*==============================================================*/
/* Table : PointageJournalier                                   */
/*==============================================================*/
create table PointageJournalier
(
   id_pointage          int not null,
   id_demande           int not null,
   heure_pointage       datetime,
   heure_prevu          datetime,
   primary key (id_pointage)
);

/*==============================================================*/
/* Table : RaceAnimal                                           */
/*==============================================================*/
create table RaceAnimal
(
   id_race_animal       int not null,
   id_espece_animal     int not null,
   race_animal          int,
   primary key (id_race_animal)
);

/*==============================================================*/
/* Table : RaisonAnnulationDemande                              */
/*==============================================================*/
create table RaisonAnnulationDemande
(
   id_raison_annul      int not null,
   libelle_annul_demande varchar(254),
   primary key (id_raison_annul)
);

/*==============================================================*/
/* Table : RaisonAnnulationOffre                                */
/*==============================================================*/
create table RaisonAnnulationOffre
(
   id_annulation_offre  int not null,
   libele_annulation    varchar(254),
   primary key (id_annulation_offre)
);

/*==============================================================*/
/* Table : RaisonAnnulationPrematuree                           */
/*==============================================================*/
create table RaisonAnnulationPrematuree
(
   id_raison_annul_prem int not null,
   libelle_annul_prem   varchar(254),
   primary key (id_raison_annul_prem)
);

/*==============================================================*/
/* Table : RaisonDesinscriptionUtilisateur                      */
/*==============================================================*/
create table RaisonDesinscriptionUtilisateur
(
   id_desinscription    int not null,
   id_utilisateur       int,
   libelle_desinscription varchar(254),
   primary key (id_desinscription)
);

/*==============================================================*/
/* Table : RaisonRefusDemande                                   */
/*==============================================================*/
create table RaisonRefusDemande
(
   id_motif_refus       int not null,
   libelle_refus        varchar(254),
   primary key (id_motif_refus)
);

/*==============================================================*/
/* Table : RaisonRetraitTerrain                                 */
/*==============================================================*/
create table RaisonRetraitTerrain
(
   id_raison_retrait    int not null,
   libelle_retrait_terrain int,
   primary key (id_raison_retrait)
);

/*==============================================================*/
/* Table : Terrain                                              */
/*==============================================================*/
create table Terrain
(
   id_terrain           int not null,
   id_raison_retrait    int,
   id_humidite_terraine int not null,
   id_composition_terrain int not null,
   id_pente_terrain     int not null,
   id_villeCP           int not null,
   id_hauteur_herbe     int not null,
   id_utilisateur       int not null,
   nom_terrain          varchar(254),
   surface_terrain      int,
   description_terrain  varchar(254),
   adresse_terrain      varchar(254),
   date_enregistrement_terrain datetime,
   photo_terrain        varchar(254),
   date_retrait_terrain datetime,
   primary key (id_terrain)
);

/*==============================================================*/
/* Table : TypeAnomalie                                         */
/*==============================================================*/
create table TypeAnomalie
(
   id_type_anomalie     int not null,
   type_anomalie        varchar(254),
   primary key (id_type_anomalie)
);

/*==============================================================*/
/* Table : TypeVegetation                                       */
/*==============================================================*/
create table TypeVegetation
(
   id_type_vegetation   int not null,
   type_vegetation      varchar(254),
   pourcentage_vegetation int,
   primary key (id_type_vegetation)
);

/*==============================================================*/
/* Table : TypeVegetationFavori                                 */
/*==============================================================*/
create table TypeVegetationFavori
(
   id_type_vegetation   int not null,
   id_espece_animal     int not null,
   primary key (id_type_vegetation, id_espece_animal)
);

/*==============================================================*/
/* Table : Utilisateur                                          */
/*==============================================================*/
create table Utilisateur
(
   id_utilisateur       int not null,
   id_villeCP           int not null,
   nom_utilisateur      varchar(254),
   prenom_utilisateur   varchar(254),
   mail_utilisateur     varchar(254),
   mdp_utilisateur      varchar(254),
   e                    varchar(254),
   date_inscription_utilisateur datetime,
   description_utilisateur varchar(254),
   siret_entreprise     bigint,
   date_desinscription_utilisateur datetime,
   primary key (id_utilisateur)
);

/*==============================================================*/
/* Table : VilleCP                                              */
/*==============================================================*/
create table VilleCP
(
   id_villeCP           int not null,
   nom_ville            varchar(254),
   code_postal          varchar(254),
   primary key (id_villeCP)
);

alter table Anomalie add constraint FK_Declarer foreign key (Uti_id_utilisateur)
      references Utilisateur (id_utilisateur) on delete restrict on update restrict;

alter table Anomalie add constraint FK_PrendreEnCompte foreign key (id_utilisateur)
      references Utilisateur (id_utilisateur) on delete restrict on update restrict;

alter table Anomalie add constraint FK_Renseigner foreign key (id_type_anomalie)
      references TypeAnomalie (id_type_anomalie) on delete restrict on update restrict;

alter table Anomalie add constraint FK_declarer foreign key (id_demande)
      references DemandeDeReservation (id_demande) on delete restrict on update restrict;

alter table Composition add constraint FK_Renseigner foreign key (id_terrain)
      references Terrain (id_terrain) on delete restrict on update restrict;

alter table Composition add constraint FK_Renseigner foreign key (id_type_vegetation)
      references TypeVegetation (id_type_vegetation) on delete restrict on update restrict;

alter table CompositionTerrainFavori add constraint FK_compatibiliter foreign key (id_composition_terrain)
      references CompositionTerrain (id_composition_terrain) on delete restrict on update restrict;

alter table CompositionTerrainFavori add constraint FK_compatibiliter foreign key (id_espece_animal)
      references Espece (id_espece_animal) on delete restrict on update restrict;

alter table DemandeDeReservation add constraint FK_Association_45 foreign key (id_offre_tonte)
      references OffreDeTonte (id_offre_tonte) on delete restrict on update restrict;

alter table DemandeDeReservation add constraint FK_Paturer foreign key (id_terrain)
      references Terrain (id_terrain) on delete restrict on update restrict;

alter table DemandeDeReservation add constraint FK_Payer foreign key (id_moyen_paiement)
      references MoyenPaiement (id_moyen_paiement) on delete restrict on update restrict;

alter table DemandeDeReservation add constraint FK_Renseigner foreign key (id_raison_annul)
      references RaisonAnnulationDemande (id_raison_annul) on delete restrict on update restrict;

alter table DemandeDeReservation add constraint FK_Renseigner foreign key (id_raison_annul_prem)
      references RaisonAnnulationPrematuree (id_raison_annul_prem) on delete restrict on update restrict;

alter table DemandeDeReservation add constraint FK_Renseigner foreign key (id_motif_refus)
      references RaisonRefusDemande (id_motif_refus) on delete restrict on update restrict;

alter table EvaluationPrestation add constraint FK_EvaluationClient foreign key (id_utilisateur)
      references Utilisateur (id_utilisateur) on delete restrict on update restrict;

alter table EvaluationPrestation add constraint FK_EvaluationEleveur foreign key (Uti_id_utilisateur)
      references Utilisateur (id_utilisateur) on delete restrict on update restrict;

alter table EvaluationPrestation add constraint FK_Evaluer foreign key (id_demande)
      references DemandeDeReservation (id_demande) on delete restrict on update restrict;

alter table HauteurHerbeFavori add constraint FK_Association_35 foreign key (id_espece_animal)
      references Espece (id_espece_animal) on delete restrict on update restrict;

alter table HauteurHerbeFavori add constraint FK_Association_35 foreign key (id_hauteur_herbe)
      references HauteurHerbe (id_hauteur_herbe) on delete restrict on update restrict;

alter table HumiditeTerrainFavori add constraint FK_Association_42 foreign key (id_espece_animal)
      references Espece (id_espece_animal) on delete restrict on update restrict;

alter table HumiditeTerrainFavori add constraint FK_Association_42 foreign key (id_humidite_terraine)
      references HumiditeTerrain (id_humidite_terraine) on delete restrict on update restrict;

alter table OffreDeTonte add constraint FK_Association_21 foreign key (id_race_animal)
      references RaceAnimal (id_race_animal) on delete restrict on update restrict;

alter table OffreDeTonte add constraint FK_Localiser foreign key (id_villeCP)
      references VilleCP (id_villeCP) on delete restrict on update restrict;

alter table OffreDeTonte add constraint FK_Proposer foreign key (id_utilisateur)
      references Utilisateur (id_utilisateur) on delete restrict on update restrict;

alter table OffreDeTonte add constraint FK_Renseigner foreign key (id_annulation_offre)
      references RaisonAnnulationOffre (id_annulation_offre) on delete restrict on update restrict;

alter table PenteTerrainFavori add constraint FK_Association_44 foreign key (id_espece_animal)
      references Espece (id_espece_animal) on delete restrict on update restrict;

alter table PenteTerrainFavori add constraint FK_Association_44 foreign key (id_pente_terrain)
      references PenteTerrain (id_pente_terrain) on delete restrict on update restrict;

alter table PointageJournalier add constraint FK_pointer foreign key (id_demande)
      references DemandeDeReservation (id_demande) on delete restrict on update restrict;

alter table RaceAnimal add constraint FK_Association_41 foreign key (id_espece_animal)
      references Espece (id_espece_animal) on delete restrict on update restrict;

alter table RaisonDesinscriptionUtilisateur add constraint FK_Renseigner foreign key (id_utilisateur)
      references Utilisateur (id_utilisateur) on delete restrict on update restrict;

alter table Terrain add constraint FK_Association_46 foreign key (id_raison_retrait)
      references RaisonRetraitTerrain (id_raison_retrait) on delete restrict on update restrict;

alter table Terrain add constraint FK_Localiser foreign key (id_villeCP)
      references VilleCP (id_villeCP) on delete restrict on update restrict;

alter table Terrain add constraint FK_Posseder foreign key (id_utilisateur)
      references Utilisateur (id_utilisateur) on delete restrict on update restrict;

alter table Terrain add constraint FK_Renseigner foreign key (id_composition_terrain)
      references CompositionTerrain (id_composition_terrain) on delete restrict on update restrict;

alter table Terrain add constraint FK_Renseigner foreign key (id_hauteur_herbe)
      references HauteurHerbe (id_hauteur_herbe) on delete restrict on update restrict;

alter table Terrain add constraint FK_Renseigner foreign key (id_humidite_terraine)
      references HumiditeTerrain (id_humidite_terraine) on delete restrict on update restrict;

alter table Terrain add constraint FK_Renseigner foreign key (id_pente_terrain)
      references PenteTerrain (id_pente_terrain) on delete restrict on update restrict;

alter table TypeVegetationFavori add constraint FK_Association_43 foreign key (id_espece_animal)
      references Espece (id_espece_animal) on delete restrict on update restrict;

alter table TypeVegetationFavori add constraint FK_Association_43 foreign key (id_type_vegetation)
      references TypeVegetation (id_type_vegetation) on delete restrict on update restrict;

alter table Utilisateur add constraint FK_Localiser foreign key (id_villeCP)
      references VilleCP (id_villeCP) on delete restrict on update restrict;

