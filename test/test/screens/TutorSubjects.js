import React from "react";
import { View, Button, Text, StyleSheet } from "react-native";
import { useState } from "react";
import { ScrollView } from "react-native";

const TutorSubjects = () => {
  const [tableData, setTableData] = useState([
    { id: 1, Fee: 50, Enrollments: 0, Subject: "Matematyka" },
    { id: 2, Fee: 100, Enrollments: 2, Subject: "Fizyka" },
    { id: 3, Fee: 1000, Enrollments: 1, Subject: "Matematyka" },
    { id: 4, Fee: 5, Enrollments: 5, Subject: "Jęz. Angielski" },
  ]);

  return (
    <ScrollView>
      <View style={styles.container}>
        <Text
          style={{
            textAlign: "center",
            fontSize: 30,
            paddingTop: 60,
            flex: 1,
            fontWeight: "600",
            color: "#A40303",
          }}
        >
          Moje oferty
        </Text>

        <View
          style={{
            marginTop: 30,
            marginLeft: 15,
            flex: 1,
            alignSelf: "stretch",
            borderWidth: 2,
            borderColor: "black",
            borderRadius: 15,
            padding: 10,
            marginRight: 8,
            backgroundColor: "white",

            //flexDirection: 'row',
          }}
        >
          <View style={styles.tableHeader}>
            <Text style={styles.headerText}>Cena za spotkanie</Text>
            <Text style={styles.headerText}>Przedmiot</Text>
            <Text style={styles.headerText}>Ilość rezerwacji</Text>
          </View>
          {tableData.map((item) => (
            <View key={item.id} style={styles.tableRow}>
              <Text style={styles.rowText}>{item.Fee}</Text>
              <Text style={styles.rowText}>{item.Subject}</Text>
              <Text style={styles.rowText}>{item.Enrollments}</Text>
            </View>
          ))}
        </View>
      </View>
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
    backgroundColor: "#F8FCD4",
  },
  tableHeader: {
    flexDirection: "row",
    justifyContent: "space-between",
    borderBottomWidth: 1,
    borderColor: "#ccc",
    paddingBottom: 10,
    marginBottom: 10,
    overflow: "scroll",
  },
  headerText: {
    fontWeight: "bold",
    fontSize: 16,
    width: "30%",
  },
  tableRow: {
    flexDirection: "row",
    justifyContent: "space-between",
    borderBottomWidth: 1,
    borderColor: "#ccc",
    paddingBottom: 10,
    marginBottom: 10,
  },
  rowText: {
    fontSize: 16,
    width: "30%",
  },
});

export default TutorSubjects;
