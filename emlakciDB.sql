--
-- PostgreSQL database dump
--

-- Dumped from database version 10.1
-- Dumped by pg_dump version 10.1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: daire; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE daire (
    daireid integer NOT NULL,
    daireno integer NOT NULL,
    bulundugukat integer NOT NULL,
    buyuklugu integer NOT NULL,
    fiyat money NOT NULL,
    aciklama character varying,
    tuvaletsayisi integer,
    aidatucreti money DEFAULT '?0,00'::money NOT NULL,
    cephe character varying,
    gorevliid integer NOT NULL,
    binaid integer NOT NULL,
    odasayisi character varying,
    isiyalitimi character varying
);


ALTER TABLE daire OWNER TO postgres;

--
-- Name: Daire_BinaID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "Daire_BinaID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Daire_BinaID_seq" OWNER TO postgres;

--
-- Name: Daire_BinaID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "Daire_BinaID_seq" OWNED BY daire.binaid;


--
-- Name: Daire_GorevliID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE "Daire_GorevliID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE "Daire_GorevliID_seq" OWNER TO postgres;

--
-- Name: Daire_GorevliID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE "Daire_GorevliID_seq" OWNED BY daire.gorevliid;


--
-- Name: bina; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE bina (
    binaid integer NOT NULL,
    binakod character varying NOT NULL,
    dairesayisi integer NOT NULL,
    katsayisi integer NOT NULL,
    aciklama character varying,
    siteid integer,
    asansorsayisi integer DEFAULT 0 NOT NULL,
    yapilistarihi date,
    havuzbilgisi character varying
);


ALTER TABLE bina OWNER TO postgres;

--
-- Name: dairegorevlileri; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE dairegorevlileri (
    gorevliid integer NOT NULL,
    adi character varying NOT NULL,
    soyadi character varying,
    telefonno integer
);


ALTER TABLE dairegorevlileri OWNER TO postgres;

--
-- Name: dairesahibi; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE dairesahibi (
    sahipid integer NOT NULL,
    adi character varying NOT NULL,
    soyadi character varying NOT NULL,
    telefonno character varying NOT NULL,
    adresi character varying
);


ALTER TABLE dairesahibi OWNER TO postgres;

--
-- Name: site; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE site (
    siteid integer NOT NULL,
    siteadi character varying NOT NULL,
    bloksayisi integer,
    dairesayisi integer,
    hakkinda character varying,
    guvenlikgorevlisisayisi integer DEFAULT 0,
    il character varying(50),
    ilce character varying,
    mahalle character varying,
    sokak character varying
);


ALTER TABLE site OWNER TO postgres;

--
-- Name: yonetici; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE yonetici (
    yoneticiid integer NOT NULL,
    yoneticiadi character varying NOT NULL,
    yoneticisifre character varying NOT NULL,
    epostaadresi character varying NOT NULL,
    yoneticisoyadi character varying
);


ALTER TABLE yonetici OWNER TO postgres;

--
-- Name: daire gorevliid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY daire ALTER COLUMN gorevliid SET DEFAULT nextval('"Daire_GorevliID_seq"'::regclass);


--
-- Name: daire binaid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY daire ALTER COLUMN binaid SET DEFAULT nextval('"Daire_BinaID_seq"'::regclass);


--
-- Name: bina Bina_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY bina
    ADD CONSTRAINT "Bina_pkey" PRIMARY KEY (binaid);


--
-- Name: dairegorevlileri DaireGorevlileri_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY dairegorevlileri
    ADD CONSTRAINT "DaireGorevlileri_pkey" PRIMARY KEY (gorevliid);


--
-- Name: dairesahibi DaireSahibi_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY dairesahibi
    ADD CONSTRAINT "DaireSahibi_pkey" PRIMARY KEY (sahipid);


--
-- Name: daire Daire_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY daire
    ADD CONSTRAINT "Daire_pkey" PRIMARY KEY (daireid);


--
-- Name: site Site_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY site
    ADD CONSTRAINT "Site_pkey" PRIMARY KEY (siteid);


--
-- Name: yonetici Yonetici_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY yonetici
    ADD CONSTRAINT "Yonetici_pkey" PRIMARY KEY (yoneticiid);


--
-- Name: fki_BinaSite_fkey; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_BinaSite_fkey" ON bina USING btree (siteid);


--
-- Name: fki_DaireBina_fkey; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "fki_DaireBina_fkey" ON daire USING btree (binaid);


--
-- Name: bina BinaSite_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY bina
    ADD CONSTRAINT "BinaSite_fkey" FOREIGN KEY (siteid) REFERENCES site(siteid);


--
-- Name: daire DaireBina_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY daire
    ADD CONSTRAINT "DaireBina_fkey" FOREIGN KEY (binaid) REFERENCES bina(binaid);


--
-- PostgreSQL database dump complete
--

