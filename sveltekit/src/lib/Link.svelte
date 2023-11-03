<script lang="ts">
	export let text: string | null = null;
	export let url: string;

	const hasSlot = $$slots.default;
</script>

{#if text}
	<a href={url}>{text}</a>
{:else if hasSlot}
	<a href={url}><slot /></a>
{:else}
	<a href={url}>{url}</a>
{/if}
