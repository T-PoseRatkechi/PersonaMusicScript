<script lang="ts">
	export let text: string | null = null;
	export let url: string;
</script>

{#if text}
	<a href={url}>{text}</a>
{:else}
	<a href={url}><slot /></a>
{/if}
