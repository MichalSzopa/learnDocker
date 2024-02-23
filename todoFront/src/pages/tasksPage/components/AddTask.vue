<template>
    <v-dialog v-model="dialog" persistent max-width="290">
        <form @submit.prevent="submitForm">
    <div>
      <label for="isRecurring">Is Recurring:</label>
      <input type="checkbox" id="isRecurring" v-model="task.isRecurring" />
    </div>
    <div>
      <label for="eventDate">Event Date:</label>
      <input type="date" id="eventDate" v-model="task.eventDate" />
    </div>
    <div>
      <label for="time">Time:</label>
      <input type="time" id="time" v-model="task.time" />
    </div>
    <div>
      <label for="title">Title:</label>
      <input type="text" id="title" v-model="task.title" />
    </div>
    <div>
      <label for="description">Description:</label>
      <textarea id="description" v-model="task.description"></textarea>
    </div>
    <div>
      <label for="categoryId">Category ID:</label>
      <input type="number" id="categoryId" v-model="task.categoryId" />
    </div>
    <div>
      <label for="repetition">Repetition:</label>
      <select id="repetition" v-model="task.repetition">
        <option disabled value="">Please select one</option>
        <option value="Daily">Daily</option>
        <option value="Weekly">Weekly</option>
        <!-- Add other repetition options as needed -->
      </select>
    </div>
    <div>
      <label for="priority">Priority:</label>
      <select id="priority" v-model="task.priority">
        <option disabled value="">Please select one</option>
        <option value="High">High</option>
        <option value="Medium">Medium</option>
        <option value="Low">Low</option>
      </select>
    </div>
    <div>
      <label for="status">Status:</label>
      <select id="status" v-model="task.status">
        <option disabled value="">Please select one</option>
        <option value="Pending">Pending</option>
        <option value="Completed">Completed</option>
        <!-- Add other status options as needed -->
      </select>
    </div>
    <div>
      <label for="parentId">Parent ID:</label>
      <input type="number" id="parentId" v-model="task.parentId" />
    </div>
    <div>
      <label for="projectId">Project ID:</label>
      <input type="number" id="projectId" v-model="task.projectId" />
    </div>
    <button type="submit" @click="onButtonClicked">Submit</button>
  </form>
    </v-dialog>
  </template>

<script>
import { toRaw } from 'vue';
import { mapActions } from 'vuex';


export default {
  data () {
    return {
      dialog: true,
      task: {
        isRecurring: false,
        creationDate: null,
        eventDate: null,
        time: null,
        title: '',
        description: '',
        categoryId: null,
        repetition: null,
        priority: null,
        status: null,
        parentId: null,
        projectId: null,
      },
    }
  },
  methods: {
    ...mapActions('tasks', ['createTask']),
    onButtonClicked() {
        this.dialog = false;
        console.log(toRaw(this.task));
        this.createTask(this.task);
        this.$emit('closeDialog');
    }
  }
}
</script>