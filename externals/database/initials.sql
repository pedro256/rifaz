-- Extensão para UUID
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE users (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    full_name VARCHAR(250) NOT NULL,
    email VARCHAR(150) UNIQUE,
    profile_image varchar,
    created_at TIMESTAMP NOT NULL DEFAULT NOW(),
    kc_id UUID NOT NULL
);

CREATE TABLE raffle (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    title VARCHAR(200) NOT NULL,
    raffle_description TEXT,
    raffle_date DATE NOT NULL,
    horario_sorteio TIME,
    raffle_status integer NOT NULL DEFAULT 0, -- pendente(0),--ativa(1),finalizada(2),cancelada(3) 
    ticket_value NUMERIC(10,2) NOT NULL,
    owner_id UUID NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT NOW(),

    CONSTRAINT fk_raffle_owner
        FOREIGN KEY (owner_id)
        REFERENCES users(id)
        ON DELETE CASCADE
);

CREATE TABLE tickets (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    raffle_id UUID NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT NOW(),
    approved_date TIMESTAMP,
    ticket_status integer NOT NULL DEFAULT 0,-- pendente(0),--ativa(1),cancelado(2)

    name_indentification VARCHAR(150) NOT NULL,
    email VARCHAR(150) NOT NULL,
    phone VARCHAR(30),
    unic_indentificator_view VARCHAR(50) NOT NULL, -- numero da rifa, indenficador visual para sorteio

    CONSTRAINT fk_ticket_raffle
        FOREIGN KEY (raffle_id)
        REFERENCES raffle(id)
        ON DELETE CASCADE
);


CREATE INDEX idx_raffle_owner ON raffle(owner_id);
CREATE INDEX idx_tickets_raffle ON tickets(raffle_id);
