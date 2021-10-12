--
-- PostgreSQL database dump
--

-- Dumped from database version 14.0
-- Dumped by pg_dump version 14.0

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: darpaises(); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.darpaises()
    LANGUAGE plpgsql
    AS $$
begin

perform p.codigo_pais 
from pais p;
end;
$$;


ALTER PROCEDURE public.darpaises() OWNER TO postgres;

--
-- Name: insetarpais(character, character, character, character, numeric, integer, numeric, numeric, character, character, numeric); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.insetarpais(IN character, IN character, IN character, IN character, IN numeric, IN integer, IN numeric, IN numeric, IN character, IN character, IN numeric)
    LANGUAGE plpgsql
    AS $_$
begin 
insert into pais (codigo_pais, continente, nombre, region, anio, poblacion, esperanza, pib, gobierno, presidente, superficie)
values ($1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11);
commit;

end;
$_$;


ALTER PROCEDURE public.insetarpais(IN character, IN character, IN character, IN character, IN numeric, IN integer, IN numeric, IN numeric, IN character, IN character, IN numeric) OWNER TO postgres;

--
-- Name: seleccionar_pais_pk(character); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.seleccionar_pais_pk(id character) RETURNS character
    LANGUAGE plpgsql
    AS $$
BEGIN
 RETURN 'lkj';
END;
$$;


ALTER FUNCTION public.seleccionar_pais_pk(id character) OWNER TO postgres;

--
-- Name: seleccionar_pais_pk2(character); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.seleccionar_pais_pk2(IN codigo character)
    LANGUAGE plpgsql
    AS $$

begin

perform * 
from pais
where codigo_pais=codigo;
end;
$$;


ALTER PROCEDURE public.seleccionar_pais_pk2(IN codigo character) OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: ciudad; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.ciudad (
    codigo_ciudad integer NOT NULL,
    nombre character varying(45),
    distrito character varying(45),
    poblacion integer,
    codigo_pais character varying(3)
);


ALTER TABLE public.ciudad OWNER TO postgres;

--
-- Name: ciudad2_codigo_ciudad_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.ciudad2_codigo_ciudad_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.ciudad2_codigo_ciudad_seq OWNER TO postgres;

--
-- Name: ciudad2_codigo_ciudad_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.ciudad2_codigo_ciudad_seq OWNED BY public.ciudad.codigo_ciudad;


--
-- Name: idioma; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.idioma (
    id_idioma integer NOT NULL,
    nombre character varying(45),
    oficial integer,
    porcentajeutilizacion numeric(5,2),
    codigo_pais character(3)
);


ALTER TABLE public.idioma OWNER TO postgres;

--
-- Name: idioma_id_idioma_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.idioma_id_idioma_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.idioma_id_idioma_seq OWNER TO postgres;

--
-- Name: idioma_id_idioma_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.idioma_id_idioma_seq OWNED BY public.idioma.id_idioma;


--
-- Name: pais; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.pais (
    codigo_pais character varying(3) NOT NULL,
    continente character varying(45),
    nombre character varying,
    region character varying,
    anio numeric(4,0),
    poblacion integer,
    esperanza numeric(4,1),
    pib numeric(10,2),
    gobierno character varying,
    presidente character varying,
    superficie numeric(12,2)
);


ALTER TABLE public.pais OWNER TO postgres;

--
-- Name: ciudad codigo_ciudad; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ciudad ALTER COLUMN codigo_ciudad SET DEFAULT nextval('public.ciudad2_codigo_ciudad_seq'::regclass);


--
-- Name: idioma id_idioma; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.idioma ALTER COLUMN id_idioma SET DEFAULT nextval('public.idioma_id_idioma_seq'::regclass);


--
-- Data for Name: ciudad; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.ciudad (codigo_ciudad, nombre, distrito, poblacion, codigo_pais) FROM stdin;
8	Pasto	Nariño	2000000	col
9	Ipiales	Nariño	300000	col
10	Tumaco	Nariño	200000	col
11	Guayaquil	Guayas	6000000	ecu
12	Tulcan	Carchi	250000	ecu
14	Lima	Capital	7000000	per
\.


--
-- Data for Name: idioma; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.idioma (id_idioma, nombre, oficial, porcentajeutilizacion, codigo_pais) FROM stdin;
3	Español	1	50.00	ecu
4	Inglés	1	20.00	ecu
6	Español	1	10.00	col
7	mandarin	0	15.00	ecu
8	Inglés	0	50.00	col
9	Nativo	0	20.00	per
\.


--
-- Data for Name: pais; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.pais (codigo_pais, continente, nombre, region, anio, poblacion, esperanza, pib, gobierno, presidente, superficie) FROM stdin;
ecu	America	Ecuador	sur	1900	2000000	12.0	5.00	republica	lenin	5000.00
per	America	Peru	nor	1900	2000000	15.0	15.00	republica	fugi	5000.00
arg	America	Argentina	Sur	1993	50000000	500.0	500.00	totalitario	rua	4000.00
col	America	Colombia	sur	1820	50000000	120.0	5.00	republica	duque	3000.00
mex	america	mexico	centro	1810	40000000	124.0	12.00	republica	peña	3000.00
\.


--
-- Name: ciudad2_codigo_ciudad_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.ciudad2_codigo_ciudad_seq', 14, true);


--
-- Name: idioma_id_idioma_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.idioma_id_idioma_seq', 10, true);


--
-- Name: ciudad ciudad2_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ciudad
    ADD CONSTRAINT ciudad2_pkey PRIMARY KEY (codigo_ciudad);


--
-- Name: idioma idioma_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.idioma
    ADD CONSTRAINT idioma_pkey PRIMARY KEY (id_idioma);


--
-- Name: pais nombre_pais_uq; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.pais
    ADD CONSTRAINT nombre_pais_uq UNIQUE (nombre);


--
-- Name: pais pais_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.pais
    ADD CONSTRAINT pais_pkey PRIMARY KEY (codigo_pais);


--
-- Name: fki_pais_fkey; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_pais_fkey ON public.ciudad USING btree (codigo_pais);


--
-- Name: idioma pais_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.idioma
    ADD CONSTRAINT pais_fkey FOREIGN KEY (codigo_pais) REFERENCES public.pais(codigo_pais) NOT VALID;


--
-- Name: ciudad pais_fkeyy; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.ciudad
    ADD CONSTRAINT pais_fkeyy FOREIGN KEY (codigo_pais) REFERENCES public.pais(codigo_pais) NOT VALID;


--
-- PostgreSQL database dump complete
--

