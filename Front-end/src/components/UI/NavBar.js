import styles from "./NavBar.module.css";

const NavBar = () => {
    return (
        <div>
            <div className={styles['topnav']}>
                <div className={styles['topnav-centered']}>
                    {/* <p>Hello {getFirstName()}!</p> */}
                    <p>Hello, Mindaugas!</p>
                </div>
                <div className={styles['topnav-right']}>
                    {/* <a href="/login" onClick={removeUserSession}>Logout</a> */}
                    <a href="/login">Logout</a>
                </div>
            </div>
        </div>
    );
};

export default NavBar;