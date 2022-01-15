import NewContactForm from "../Contacts/NewContactForm";
import NavBar from "../UI/NavBar";
import UserContactsList from "../Contacts/UserContactsList";
import { useState } from "react";

const HomeView = () => {

    return (
        <div>
            <NavBar />
            <NewContactForm />
            <UserContactsList />
        </div >
    );
};

export default HomeView;