import LoginForm from "./LoginForm";
import styles from "./LoginView.module.css";
import Card from "../UI/Card";
import { Link } from "react-router-dom";

const LoginView = () => {
    return (
        <Card className={styles['login-view']}>
            <LoginForm />
            <div className={styles['login-view__text']}>
                Don't have an account?
            </div>
            <Link to="/register">Sign up!</Link>
        </Card>
    );
};

export default LoginView;