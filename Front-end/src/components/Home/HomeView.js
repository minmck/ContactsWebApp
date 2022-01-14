import Card from "../UI/Card";
import NewContactForm from "../Contacts/NewContactForm";
import styles from "./HomeView.module.css";
import NavBar from "../UI/NavBar";
import UserContactsList from "../Contacts/UserContactsList";

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