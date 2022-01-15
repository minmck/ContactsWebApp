import styles from "./NavBar.module.css";
import { getFirstName, removeUserSession } from "../../utils/Common";
import { useHistory } from "react-router-dom/cjs/react-router-dom.min";

const NavBar = () => {
    const history = useHistory();

    const logout = () => {
        removeUserSession();
        history.push('/login');
    };

    return (
        <div>
            <div className={styles['topnav']}>
                <div className={styles['topnav-centered']}>
                    <p>Hello {getFirstName()}!</p>
                </div>
                <div className={styles['topnav-right']}>
                    <button onClick={logout}>Logout</button>
                </div>
            </div>
        </div>
    );
};

export default NavBar;