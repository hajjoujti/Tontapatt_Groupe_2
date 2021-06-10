/*==============================================================*/
/* Nom de SGBD :  MySQL 5.0                                     */
/* Date de création :  09/06/2021 15:47:04                      */
/*==============================================================*/


drop table if exists Anomalie;

drop table if exists Composition;

drop table if exists CompositionTerrainFavori;

drop table if exists EvaluationPrestation;

drop table if exists PointageJournalier;

drop table if exists DemandeDeReservation;

drop table if exists Terrain;

drop table if exists CompositionTerrain;

drop table if exists HauteurHerbeFavori;

drop table if exists HauteurHerbe;

drop table if exists HumiditeTerrainFavori;

drop table if exists HumiditeTerrain;

drop table if exists PenteTerrainFavori;

drop table if exists PenteTerrain;

drop table if exists OffreDeTonte;

drop table if exists RaceAnimal;

drop table if exists TypeVegetationFavori;

drop table if exists TypeVegetation;

drop table if exists Espece;

drop table if exists MoyenPaiement;

drop table if exists RaisonAnnulationDemande;

drop table if exists RaisonAnnulationOffre;

drop table if exists RaisonAnnulationPrematuree;

drop table if exists Utilisateur;

drop table if exists RaisonDesinscriptionUtilisateur;

drop table if exists RaisonRefusDemande;

drop table if exists RaisonRetraitTerrain;

drop table if exists TypeAnomalie;

drop table if exists VilleCP;

/*==============================================================*/
/* Table: Anomalie                                              */
/*==============================================================*/
create table Anomalie
(
   id_anomalie          int not null auto_increment  comment '',
   id_demande           int not null  comment '',
   id_utilisateur_client       int not null comment '',
   id_utilisateur_eleveur   int not null comment '',
   id_type_anomalie     int not null  comment '',
   description_anomalie varchar(254) not null comment '',
   date_declenchement_anomalie datetime not null comment '',
   date_fin_anomalie    datetime  comment '',
   primary key (id_anomalie)
);

/*==============================================================*/
/* Table: Composition                                           */
/*==============================================================*/
create table Composition
(
   id_type_vegetation   int not null  comment '',
   id_terrain           int not null  comment '',
   pourcentage_vegetation int not null comment '',
   primary key (id_type_vegetation, id_terrain)
);

/*==============================================================*/
/* Table: CompositionTerrain                                    */
/*==============================================================*/
create table CompositionTerrain
(
   id_composition_terrain int not null auto_increment  comment '',
   composition_terrain  varchar(254) not null comment '',
   primary key (id_composition_terrain)
);

/*==============================================================*/
/* Table: CompositionTerrainFavori                              */
/*==============================================================*/
create table CompositionTerrainFavori
(
   id_composition_terrain int not null  comment '',
   id_espece_animal     int not null  comment '',
   primary key (id_composition_terrain, id_espece_animal)
);

/*==============================================================*/
/* Table: DemandeDeReservation                                  */
/*==============================================================*/
create table DemandeDeReservation
(
   id_demande           int not null auto_increment  comment '',
   id_raison_annul_prem int  comment '',
   id_terrain           int not null  comment '',
   id_raison_annul      int  comment '',
   id_motif_refus       int  comment '',
   id_moyen_paiement    int not null comment '',
   id_offre             int not null comment '',
   date_debut_demande   datetime  not null comment '',
   date_fin_demande     datetime not null  comment '',
   cout_demande         double(8,0) not null comment '',
   date_acceptaion_demande datetime  comment '',
   date_annulation_demande datetime  comment '',
   date_creation_demande datetime  comment '',
   date_installation_troupeau datetime  comment '',
   date_annulation_prematuree datetime  comment '',
   numero_reservation   int not null  comment '',
   date_refus_demande   datetime  comment '',
   UNIQUE KEY (numero_reservation),
   primary key (id_demande)
);

/*==============================================================*/
/* Table: Espece                                                */
/*==============================================================*/
create table Espece
(
   id_espece_animal     int not null auto_increment  comment '',
   espece_animal        varchar(254) not null comment '',
   primary key (id_espece_animal)
);

/*==============================================================*/
/* Table: EvaluationPrestation                                  */
/*==============================================================*/
create table EvaluationPrestation
(
   id_eval_prestation   int not null auto_increment  comment '',
   id_utilisateur_client       int not null comment '',
   id_demande           int  not null  comment '',
   id_utilisateur_eleveur   int not null comment '',
   note_prestation      int not null comment '',
   remarque_eval        varchar(254)  comment '',
   primary key (id_eval_prestation)
);

/*==============================================================*/
/* Table: HauteurHerbe                                          */
/*==============================================================*/
create table HauteurHerbe
(
   id_hauteur_herbe     int not null auto_increment  comment '',
   hauteur_herbe        varchar(254) not null comment '',
   primary key (id_hauteur_herbe)
);

/*==============================================================*/
/* Table: HauteurHerbeFavori                                    */
/*==============================================================*/
create table HauteurHerbeFavori
(
   id_hauteur_herbe     int not null  comment '',
   id_espece_animal     int not null  comment '',
   primary key (id_hauteur_herbe, id_espece_animal)
);

/*==============================================================*/
/* Table: HumiditeTerrain                                       */
/*==============================================================*/
create table HumiditeTerrain
(
   id_humidite_terrain int not null auto_increment  comment '',
   humidite_terrain     varchar(254) not null comment '',
   primary key (id_humidite_terrain)
);

/*==============================================================*/
/* Table: HumiditeTerrainFavori                                 */
/*==============================================================*/
create table HumiditeTerrainFavori
(
   id_humidite_terrain int not null  comment '',
   id_espece_animal     int not null  comment '',
   primary key (id_humidite_terrain, id_espece_animal)
);

/*==============================================================*/
/* Table: MoyenPaiement                                         */
/*==============================================================*/
create table MoyenPaiement
(
   id_moyen_paiement    int not null auto_increment  comment '',
   type_moyen_paiement  varchar(254) not null comment '',
   primary key (id_moyen_paiement)
);

/*==============================================================*/
/* Table: OffreDeTonte                                          */
/*==============================================================*/
create table OffreDeTonte
(
   id_offre             int not null auto_increment  comment '',
   id_race_animal       int not null  comment '',
   id_annulation_offre  int  comment '',
   id_utilisateur       int not null  comment '',
   id_villecp           int not null  comment '',
   nom_offre            varchar(254) not null comment '',
   adresse_troupeau     varchar(254) not null comment '',
   date_debut_offre     datetime not null comment '',
   date_fin_offre       datetime not null comment '',
   date_creation_offre  datetime not null comment '',
   description_offre    varchar(254)  comment '',
   distance_maximale    int not null comment '',
   cout_anilmal_par_jour double(8,0) not null comment '',
   date_annulation_offre datetime  comment '',
   nombre_animaux       int not null comment '',
   primary key (id_offre)
);

/*==============================================================*/
/* Table: PenteTerrain                                          */
/*==============================================================*/
create table PenteTerrain
(
   id_pente_terrain     int not null auto_increment  comment '',
   pente_terrain        varchar(254) not null comment '',
   primary key (id_pente_terrain)
);

/*==============================================================*/
/* Table: PenteTerrainFavori                                    */
/*==============================================================*/
create table PenteTerrainFavori
(
   id_pente_terrain     int not null  comment '',
   id_espece_animal     int not null  comment '',
   primary key (id_pente_terrain, id_espece_animal)
);

/*==============================================================*/
/* Table: PointageJournalier                                    */
/*==============================================================*/
create table PointageJournalier
(
   id_pointage          int not null auto_increment  comment '',
   id_demande           int not null  comment '',
   heure_pointage       datetime not null comment '',
   heure_prevu          datetime not null comment '',
   primary key (id_pointage)
);

/*==============================================================*/
/* Table: RaceAnimal                                            */
/*==============================================================*/
create table RaceAnimal
(
   id_race_animal       int not null auto_increment  comment '',
   id_espece_animal     int not null  comment '',
   race_animal          varchar(254) not null comment '',
   primary key (id_race_animal)
);

/*==============================================================*/
/* Table: RaisonAnnulationDemande                               */
/*==============================================================*/
create table RaisonAnnulationDemande
(
   id_raison_annul      int not null auto_increment  comment '',
   libelle_annul_demande varchar(254) not null comment '',
   primary key (id_raison_annul)
);

/*==============================================================*/
/* Table: RaisonAnnulationOffre                                 */
/*==============================================================*/
create table RaisonAnnulationOffre
(
   id_annulation_offre  int not null auto_increment  comment '',
   libele_annulation    varchar(254) not null comment '',
   primary key (id_annulation_offre)
);

/*==============================================================*/
/* Table: RaisonAnnulationPrematuree                            */
/*==============================================================*/
create table RaisonAnnulationPrematuree
(
   id_raison_annul_prem int not null auto_increment  comment '',
   libelle_annul_prem   varchar(254) not null comment '',
   primary key (id_raison_annul_prem)
);

/*==============================================================*/
/* Table: RaisonDesinscriptionUtilisateur                       */
/*==============================================================*/
create table RaisonDesinscriptionUtilisateur
(
   id_desinscription    int not null auto_increment  comment '',
   libelle_desinscription varchar(254) not null comment '',
   primary key (id_desinscription)
);

/*==============================================================*/
/* Table: RaisonRefusDemande                                    */
/*==============================================================*/
create table RaisonRefusDemande
(
   id_motif_refus       int not null auto_increment  comment '',
   libelle_refus        varchar(254) not null comment '',
   primary key (id_motif_refus)
);

/*==============================================================*/
/* Table: RaisonRetraitTerrain                                  */
/*==============================================================*/
create table RaisonRetraitTerrain
(
   id_raison_retrait    int not null auto_increment  comment '',
   libelle_retrait_terrain int not null comment '',
   primary key (id_raison_retrait)
);

/*==============================================================*/
/* Table: Terrain                                               */
/*==============================================================*/
create table Terrain
(
   id_terrain           int not null auto_increment  comment '',
   id_raison_retrait    int  comment '',
   id_humidite_terrain int not null  comment '',
   id_composition_terrain int not null  comment '',
   id_pente_terrain     int not null  comment '',
   id_villecp           int not null  comment '',
   id_hauteur_herbe     int not null  comment '',
   id_utilisateur       int not null  comment '',
   nom_terrain          varchar(254) not null comment '',
   surface_terrain      int not null comment '',
   description_terrain  varchar(254)  comment '',
   adresse_terrain      varchar(254) not null comment '',
   date_enregistrement_terrain datetime not null comment '',
   photo_terrain        varchar(254)  comment '',
   date_retrait_terrain datetime  comment '',
   primary key (id_terrain)
);

/*==============================================================*/
/* Table: TypeAnomalie                                          */
/*==============================================================*/
create table TypeAnomalie
(
   id_type_anomalie     int not null auto_increment  comment '',
   type_anomalie        varchar(254) not null comment '',
   primary key (id_type_anomalie)
);

/*==============================================================*/
/* Table: TypeVegetation                                        */
/*==============================================================*/
create table TypeVegetation
(
   id_type_vegetation   int not null auto_increment  comment '',
   type_vegetation      varchar(254) not null comment '',
   primary key (id_type_vegetation)
);

/*==============================================================*/
/* Table: TypeVegetationFavori                                  */
/*==============================================================*/
create table TypeVegetationFavori
(
   id_type_vegetation   int not null  comment '',
   id_espece_animal     int not null  comment '',
   primary key (id_type_vegetation, id_espece_animal)
);

/*==============================================================*/
/* Table: Utilisateur                                           */
/*==============================================================*/
create table Utilisateur
(
   id_utilisateur       int not null auto_increment  comment '',
   id_villecp           int not null  comment '',
   id_desinscription    int  comment '',
   nom_utilisateur      varchar(254) not null comment '',
   prenom_utilisateur   varchar(254) not null comment '',
   mail_utilisateur     varchar(254) not null comment '',
   mdp_utilisateur      varchar(254) not null comment '',
   adresse_utilisateur  varchar(254) not null comment '',
   date_inscription_utilisateur datetime not null comment '',
   description_utilisateur varchar(254)  comment '',
   siret_entreprise     bigint  comment '',
   date_desinscription_utilisateur datetime  comment '',
   primary key (id_utilisateur)
);

/*==============================================================*/
/* Table: VilleCP                                               */
/*==============================================================*/
create table VilleCP
(
   id_villecp           int not null auto_increment  comment '',
   nom_ville            varchar(254) not null comment '',
   code_postal          varchar(254) not null comment '',
   longitude_ville		decimal not null comment '',
   latitude_ville		decimal not null comment '',
   primary key (id_villecp)
);

alter table Anomalie add constraint FK_ANOMALIE_DEMANDERE_DEMANDED foreign key (id_demande)
      references DemandeDeReservation (id_demande) on delete restrict on update restrict;

alter table Anomalie add constraint FK_ANOMALIE_IDCLIENT_UTILISAT foreign key (id_utilisateur_client)
      references Utilisateur (id_utilisateur) on delete restrict on update restrict;

alter table Anomalie add constraint FK_ANOMALIE_IDELEVEUR_UTILISAT foreign key (id_utilisateur_eleveur)
      references Utilisateur (id_utilisateur) on delete restrict on update restrict;

alter table Anomalie add constraint FK_ANOMALIE_TYPEANOMA_TYPEANOM foreign key (id_type_anomalie)
      references TypeAnomalie (id_type_anomalie) on delete restrict on update restrict;

alter table Composition add constraint FK_COMPOSIT_COMPOSITI_TERRAIN foreign key (id_terrain)
      references Terrain (id_terrain) on delete restrict on update restrict;

alter table Composition add constraint FK_COMPOSIT_COMPOSITI_TYPEVEGE foreign key (id_type_vegetation)
      references TypeVegetation (id_type_vegetation) on delete restrict on update restrict;

alter table CompositionTerrainFavori add constraint FK_COMPOSIT_COMPOSITI_COMPOSIT foreign key (id_composition_terrain)
      references CompositionTerrain (id_composition_terrain) on delete restrict on update restrict;

alter table CompositionTerrainFavori add constraint FK_COMPOSIT_COMPOSITI_ESPECE foreign key (id_espece_animal)
      references Espece (id_espece_animal) on delete restrict on update restrict;

alter table DemandeDeReservation add constraint FK_DEMANDED_MOYENPAIE_MOYENPAI foreign key (id_moyen_paiement)
      references MoyenPaiement (id_moyen_paiement) on delete restrict on update restrict;

alter table DemandeDeReservation add constraint FK_DEMANDED_OFFREDETO_OFFREDET foreign key (id_offre)
      references OffreDeTonte (id_offre) on delete restrict on update restrict;

alter table DemandeDeReservation add constraint FK_DEMANDED_RAISONANNULATION_RAISONAN foreign key (id_raison_annul)
      references RaisonAnnulationDemande (id_raison_annul) on delete restrict on update restrict;

alter table DemandeDeReservation add constraint FK_DEMANDED_RAISONANNULATIONPREMATUREE_RAISONAN foreign key (id_raison_annul_prem)
      references RaisonAnnulationPrematuree (id_raison_annul_prem) on delete restrict on update restrict;

alter table DemandeDeReservation add constraint FK_DEMANDED_RAISONREF_RAISONRE foreign key (id_motif_refus)
      references RaisonRefusDemande (id_motif_refus) on delete restrict on update restrict;

alter table DemandeDeReservation add constraint FK_DEMANDED_TERRAIN_TERRAIN foreign key (id_terrain)
      references Terrain (id_terrain) on delete restrict on update restrict;

alter table EvaluationPrestation add constraint FK_EVALUATI_DEMANDEDE_DEMANDED foreign key (id_demande)
      references DemandeDeReservation (id_demande) on delete restrict on update restrict;

alter table EvaluationPrestation add constraint FK_EVALUATI_IDCLIENT_UTILISAT foreign key (id_utilisateur_client)
      references Utilisateur (id_utilisateur) on delete restrict on update restrict;

alter table EvaluationPrestation add constraint FK_EVALUATI_IDELEVEUR_UTILISAT foreign key (id_utilisateur_eleveur)
      references Utilisateur (id_utilisateur) on delete restrict on update restrict;

alter table HauteurHerbeFavori add constraint FK_HAUTEURH_HAUTEURHE_ESPECE foreign key (id_espece_animal)
      references Espece (id_espece_animal) on delete restrict on update restrict;

alter table HauteurHerbeFavori add constraint FK_HAUTEURH_HAUTEURHE_HAUTEURH foreign key (id_hauteur_herbe)
      references HauteurHerbe (id_hauteur_herbe) on delete restrict on update restrict;

alter table HumiditeTerrainFavori add constraint FK_HUMIDITE_HUMIDITET_ESPECE foreign key (id_espece_animal)
      references Espece (id_espece_animal) on delete restrict on update restrict;

alter table HumiditeTerrainFavori add constraint FK_HUMIDITE_HUMIDITET_HUMIDITE foreign key (id_humidite_terrain)
      references HumiditeTerrain (id_humidite_terrain) on delete restrict on update restrict;

alter table OffreDeTonte add constraint FK_OFFREDET_RACEANIMA_RACEANIM foreign key (id_race_animal)
      references RaceAnimal (id_race_animal) on delete restrict on update restrict;

alter table OffreDeTonte add constraint FK_OFFREDET_RAISONANN_RAISONAN foreign key (id_annulation_offre)
      references RaisonAnnulationOffre (id_annulation_offre) on delete restrict on update restrict;

alter table OffreDeTonte add constraint FK_OFFREDET_UTILISATE_UTILISAT foreign key (id_utilisateur)
      references Utilisateur (id_utilisateur) on delete restrict on update restrict;

alter table OffreDeTonte add constraint FK_OFFREDET_VILLECP_VILLECP foreign key (id_villecp)
      references VilleCP (id_villecp) on delete restrict on update restrict;

alter table PenteTerrainFavori add constraint FK_PENTETER_PENTETERR_ESPECE foreign key (id_espece_animal)
      references Espece (id_espece_animal) on delete restrict on update restrict;

alter table PenteTerrainFavori add constraint FK_PENTETER_PENTETERR_PENTETER foreign key (id_pente_terrain)
      references PenteTerrain (id_pente_terrain) on delete restrict on update restrict;

alter table PointageJournalier add constraint FK_POINTAGE_DEMANDEDE_DEMANDED foreign key (id_demande)
      references DemandeDeReservation (id_demande) on delete restrict on update restrict;

alter table RaceAnimal add constraint FK_RACEANIM_ESPECE_ESPECE foreign key (id_espece_animal)
      references Espece (id_espece_animal) on delete restrict on update restrict;

alter table Terrain add constraint FK_TERRAIN_RAISONRET_RAISONRE foreign key (id_raison_retrait)
      references RaisonRetraitTerrain (id_raison_retrait) on delete restrict on update restrict;

alter table Terrain add constraint FK_TERRAIN_TERRAIN_C_COMPOSIT foreign key (id_composition_terrain)
      references CompositionTerrain (id_composition_terrain) on delete restrict on update restrict;

alter table Terrain add constraint FK_TERRAIN_TERRAIN_H_HAUTEURH foreign key (id_hauteur_herbe)
      references HauteurHerbe (id_hauteur_herbe) on delete restrict on update restrict;

alter table Terrain add constraint FK_TERRAIN_TERRAIN_H_HUMIDITE foreign key (id_humidite_terrain)
      references HumiditeTerrain (id_humidite_terrain) on delete restrict on update restrict;

alter table Terrain add constraint FK_TERRAIN_TERRAIN_P_PENTETER foreign key (id_pente_terrain)
      references PenteTerrain (id_pente_terrain) on delete restrict on update restrict;

alter table Terrain add constraint FK_TERRAIN_UTILISATE_UTILISAT foreign key (id_utilisateur)
      references Utilisateur (id_utilisateur) on delete restrict on update restrict;

alter table Terrain add constraint FK_TERRAIN_VILLECP_VILLECP foreign key (id_villecp)
      references VilleCP (id_villecp) on delete restrict on update restrict;

alter table TypeVegetationFavori add constraint FK_TYPEVEGE_TYPEVEGET_ESPECE foreign key (id_espece_animal)
      references Espece (id_espece_animal) on delete restrict on update restrict;

alter table TypeVegetationFavori add constraint FK_TYPEVEGE_TYPEVEGET_TYPEVEGE foreign key (id_type_vegetation)
      references TypeVegetation (id_type_vegetation) on delete restrict on update restrict;

alter table Utilisateur add constraint FK_UTILISAT_RAISONDES_RAISONDE foreign key (id_desinscription)
      references RaisonDesinscriptionUtilisateur (id_desinscription) on delete restrict on update restrict;

alter table Utilisateur add constraint FK_UTILISAT_VILLECP_VILLECP foreign key (id_villecp)
      references VilleCP (id_villecp) on delete restrict on update restrict;