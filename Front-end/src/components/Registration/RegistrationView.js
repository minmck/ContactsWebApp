import Card from "../UI/Card";
import RegistrationForm from "./RegistrationForm";
import styles from "./RegistrationView.module.css"
import { Link } from "react-router-dom";

const RegistrationView = () => {
    return (
        <Card className={styles['registration-view']}>
            <RegistrationForm />
            <div className={styles['registration-view__text']}>
                Already have an account?
            </div>
            <Link to="/login">Login!</Link>
        </Card>
    );
};

export default RegistrationView;