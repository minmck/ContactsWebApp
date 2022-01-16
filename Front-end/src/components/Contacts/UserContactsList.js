import axios from "axios";
import { useEffect, useState } from "react";
import { getUserId, getToken } from "../../utils/Common";
import Card from "../UI/Card";
import OneContact from "./OneContact";
import styles from "./UserContactsList.module.css";

const UserContactsList = () => {
    const [contacts, setContacts] = useState([]);
    const [refresh, setRefresh] = useState(false);

    useEffect(() => {
        axios.get("http://localhost:35549/api/users/" + getUserId() + "/contacts", {
            headers: {
                'Authorization': 'Bearer ' + getToken()
            }
        }).then(response => {
            console.log("response: ", response);
            setContacts(response.data);
        }).catch(error => {
            console.log('errors: ', error.response);
        })
    }, [refresh]);

    const refreshHandler = () => {
        if (refresh) {
            setRefresh(false);
        } else {
            setRefresh(true);
        }
    };

    return (
        <Card className={styles['user-contacts']}>
            <p className={styles['user-contacts__title']}>My contacts:</p>
            {contacts.map(function (contact) {
                return <OneContact contact={contact} key={contact.id} onRefresh={refreshHandler} />
            })}
        </Card>
    );
};

export default UserContactsList;