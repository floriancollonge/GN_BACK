CREATE DATABASE nursery  DEFAULT CHARACTER SET utf8 ;
USE nursery;

create table user (
    id_user integer not null primary key,
    first_name char(50) not null,
    last_name char(50) not null,
    login char(200) not null,
    password char(300) not null
);

create table prospect (
    id_prospect integer not null primary key,
    id_user integer not null references user(id_user),
    first_name char(50) not null,
    last_name char(50) not null,
    mail char(200),
    phone char(15),
    id_step integer not null references process_step(id_step),
    last_contact_date text,
    next_contact_date text,
    id_tag integer references tag(id_tag)

);

create table tag (
    id_tag integer not null primary key,
    id_user integer not null references user(id_user),
    label char(50) not null
);

create table process_step (
    id_step integer not null primary key,
    id_user integer not null references user(id_user),
    label char(50) not null,
    position integer not null,
    number_days integer
);